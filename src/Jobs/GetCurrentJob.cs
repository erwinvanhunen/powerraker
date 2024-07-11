using System.Globalization;
using System.Management.Automation;
using PowerRaker.Model.Files;
using PowerRaker.Model.Job;

namespace PowerRaker
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "CurrentJob")]
    public class GetCurrentJob : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Poll;

        [Parameter(Mandatory = false)]
        public int PollSeconds = 20;


        CancellationTokenSource tokenSource = new CancellationTokenSource();
        protected override void ExecuteCmdlet()
        {
            TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
            if (!Poll)
            {
                var job = Getjob(this);
                if (job != null && job.Filename != null)
                {
                    WriteObject(job);
                }
            }
            else
            {
                var job = Getjob(this);

                var exitLoop = false;
                var progressRecord = new ProgressRecord(0, job.Filename, $"{job.State}. ETA: {job.ETA}");
                while (!exitLoop)
                {
                    progressRecord.PercentComplete = job.Progress;

                    progressRecord.StatusDescription = $"{txtInfo.ToTitleCase(job.State)} ({job.Progress}%) ETA: {job.ETA:HH:mm:ss}";
#pragma warning restore CS8604 // Possible null reference argument.
                    WriteProgress(progressRecord);

                    Task.Delay(PollSeconds * 1000, tokenSource.Token).GetAwaiter().GetResult();

                    job = Getjob(this);
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

        protected override void StopProcessing()
        {
            tokenSource.Cancel();
            base.StopProcessing();
        }

        private static int EstimatedTime = 0;
        private static CurrentJob Getjob(KlipperCmdlet cmdlet)
        {
            CurrentJob currentJob = new();

            var objectQuery = cmdlet.GetResult<PrinterObjectsQuery>("/printer/objects/query?print_stats&virtual_sdcard");
            if (objectQuery != null)
            {
                if (objectQuery.Status != null && objectQuery.Status.PrintStats != null && objectQuery.Status.VirtualSdcard != null)
                {
                    currentJob.State = objectQuery.Status.PrintStats.State;
                    if (currentJob.State == "printing")
                    {
                        currentJob.Filename = objectQuery.Status.PrintStats.Filename;
                        var progress = objectQuery.Status.VirtualSdcard.Progress;
                        currentJob.Progress = (int)(progress * 100);
                        if (EstimatedTime == 0)
                        {
                            var metadata = cmdlet.GetResult<Metadata>($"/server/files/metadata?filename={currentJob.Filename}");
                            if (metadata != null)
                            {
                                EstimatedTime = metadata.EstimatedTime;
                            }
                        }
                        var progTime = progress * EstimatedTime;
                        var eta = EstimatedTime - progTime;
                        currentJob.ETA = DateTime.Now.AddSeconds(eta);
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