using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "JobQueueStatus")]
    public class GetJobQueue : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            
            var output = RestHelper.ExecuteGetRequest(this.Connection, "/server/job_queue/status");

            var options = new JsonSerializerOptions();
            options.Converters.Add(new UnixToNullableDateTimeConverter());
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            if (jsonDocument != null)
            {
                var jobsJson = jsonDocument.RootElement.GetProperty("result").GetProperty("queued_jobs");
                var jobs = jobsJson.Deserialize<List<Job>>();
                var status = jsonDocument.RootElement.GetProperty("result").GetProperty("queue_state");

                WriteObject(status.GetString());
                WriteObject(jobs, true);
            }
        }
    }

}