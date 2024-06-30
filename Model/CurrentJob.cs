using System.Text.Json.Serialization;

namespace powerraker
{
    public class CurrentJob
    {
        public string? Filename { get; internal set; }
        public int Layers { get; internal set; }
        public int Layer { get; internal set; }
        public int Progress { get; internal set; }
        public DateTime? ETA { get; internal set; }
        public string? State { get; internal set; }
    }
}