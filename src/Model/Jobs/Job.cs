using System.Text.Json.Serialization;

namespace PowerRaker.Model.Job
{
    public class Job
    {
        public string? Filename { get; set; }

        public string? JobID { get; set; }

        public DateTime? TimeAdded { get; set; }

        public TimeSpan TimeInQueue { get; set; }
    }
}