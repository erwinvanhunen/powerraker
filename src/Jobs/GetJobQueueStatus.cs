using System.Management.Automation;
using PowerRaker.Model.Job;

namespace PowerRaker.Jobs
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "JobQueueStatus")]
    public class GetJobQueueStatus : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var jobQueueStatus = GetResult<JobQueueStatus>("/server/job_queue/status");
            WriteObject(jobQueueStatus);
        }
    }

}