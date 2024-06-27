using System.Text.Json.Serialization;

namespace powerraker
{
    public class Job
    {
        [JsonPropertyName("filename")]
        public string Filename { get; set; }
        [JsonPropertyName("job_id")]
        public string JobID { get; set; }
        [JsonPropertyName("time_added")]
        public DateTime TimeAdded { get; set; }
        [JsonPropertyName("time_in_queue˝")]
        public TimeSpan TimeInQueue { get; set; }
    }
}