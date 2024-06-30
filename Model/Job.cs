using System.Text.Json.Serialization;

namespace powerraker
{
    public class Job
    {
        public string? Filename { get; set; }

        public string? JobID { get; set; }

        public DateTime? TimeAdded { get; set; }

        public TimeSpan TimeInQueue { get; set; }
    }
}