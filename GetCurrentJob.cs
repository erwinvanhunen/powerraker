using System.Management.Automation;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "CurrentJob")]
    public class GetCurrentJob : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Poll;

        [Parameter(Mandatory = false)]
        public int PollSeconds = 20;


        CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected override void ExecuteCmdlet()
        {
            if (!Poll)
            {
                var job = Getjob(this.Connection);
                if (job != null && job.Filename != null)
                {
                    WriteObject(job);
                }
            }
            else
            {
                var job = Getjob(this.Connection);
                if (job != null)
                {
                    var exitLoop = false;
                    var progressRecord = new ProgressRecord(0, job.Filename, $"{job.State}. ETA: {job.ETA}");
                    while (!exitLoop)
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        progressRecord.PercentComplete = job.Progress;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                        progressRecord.StatusDescription = $"{job.State}. ETA: {job.ETA}";
                        WriteProgress(progressRecord);

                        Task.Delay(PollSeconds * 1000, tokenSource.Token).GetAwaiter().GetResult();

                        job = Getjob(this.Connection);
                        if (job != null)
                        {
                            if (job.Progress == 100 || job.State == "complete")
                            {
                                exitLoop = true;
                            }
                        }
                    }
                }
            }
        }

        protected override void StopProcessing()
        {
            tokenSource.Cancel();
            base.StopProcessing();
        }

        private static CurrentJob? Getjob(RakerConnection connection)
        {

            CurrentJob? currentJob = null;

            var output = RestHelper.ExecuteGetRequest(connection, "/printer/objects/query?webhooks&virtual_sdcard&print_stats");
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            if (jsonDocument != null)
            {
                var webHooks = jsonDocument.RootElement.GetProperty("result").GetProperty("status").GetProperty("webhooks");
                var webHookStatus = webHooks.GetProperty("state").GetString();
                if (webHookStatus == "ready")
                {
                    currentJob = new CurrentJob();

                    var printStats = jsonDocument.RootElement.GetProperty("result").GetProperty("status").GetProperty("print_stats");
                    var state = printStats.GetProperty("state").GetString();
                    currentJob.State = state;
                    if (state == "printing")
                    {
                        currentJob.Filename = printStats.GetProperty("filename").GetString();
                        var sdcardInfo = jsonDocument.RootElement.GetProperty("result").GetProperty("status").GetProperty("virtual_sdcard");
                        currentJob.Layer = sdcardInfo.GetProperty("layer").GetInt32();
                        currentJob.Layers = sdcardInfo.GetProperty("layer_count").GetInt32();
                        var progress = sdcardInfo.GetProperty("progress").GetDouble();
                        currentJob.Progress = (int)(progress * 100);
                        var fileMetadataJson = RestHelper.ExecuteGetRequest(connection, $"/server/files/metadata?filename={currentJob.Filename}");
                        var fileMetadataDocument = JsonSerializer.Deserialize<JsonDocument>(fileMetadataJson);
                        if (fileMetadataDocument != null)
                        {
                            var fileMetadataElement = fileMetadataDocument.RootElement.GetProperty("result");

                            var estimatedTime = fileMetadataElement.GetProperty("estimated_time").GetInt32();
                            var progTime = progress * estimatedTime;
                            var eta = estimatedTime - progTime;
                            currentJob.ETA = DateTime.Now.AddSeconds(eta);
                        }
                    }
                }
            }
            return currentJob;
        }

        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }

}