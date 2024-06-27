using System.Text.Json.Serialization;

namespace powerraker
{
    public class Webcam
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("location")]
        public string Location { get; set; }
        [JsonPropertyName("service")]
        public string Service { get; set; }
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("target_fps")]
        public int TargetFPS { get; set; }
        [JsonPropertyName("target_fps_idle")]
        public int TargetFPSIdle { get; set; }
        [JsonPropertyName("stream_url")]
        public string StreamUrl { get; set; }
        [JsonPropertyName("snapshot_url")]
        public string SnapshotUrl { get; set; }
        [JsonPropertyName("flip_horizontal")]
        public bool FlipHorizontal { get; set; }
        [JsonPropertyName("flip_vertical")]
        public bool FlipVertical { get; set; }
        [JsonPropertyName("rotation")]
        public int Rotation { get; set; }
        [JsonPropertyName("aspect_ration")]
        public string AspectRatio { get; set; }
        [JsonPropertyName("extra_data")]
        public object ExtraData { get; set; }
        [JsonPropertyName("source")]
        public string Source { get; set; }
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
    }
}