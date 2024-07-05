namespace PowerRaker.Model.Job
{
    public class JobQueueStatus
    {
        public List<Job>? QueuedJobs { get; set; }
        public string? QueueState { get; set; }
    }
}