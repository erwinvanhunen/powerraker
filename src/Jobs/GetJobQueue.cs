using System.Management.Automation;
using PowerRaker.Model.Job;

namespace PowerRaker.Jobs
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "JobQueue")]
    public class GetJobQueue : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var jobQueueStatus = GetResult<JobQueueStatus>("/server/job_queue/status");
            WriteObject(jobQueueStatus);
        }
    }

}