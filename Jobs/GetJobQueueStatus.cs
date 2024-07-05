using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.Job;

namespace PowerRaker.Jobs
{

    [Cmdlet(VerbsCommon.Get, "JobQueueStatus")]
    public class GetJobQueueStatus : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var jobQueueStatus = GetResult<JobQueueStatus>("/server/job_queue/status");
            WriteObject(jobQueueStatus);
        }
    }

}