using System.Text.Json.Serialization;

namespace PowerRaker.Model.Webcams
{
    public class Webcam
    {
        public string? Name { get; set; }

        public string? Location { get; set; }

        public string? Service { get; set; }

        public bool Enabled { get; set; }

        public string? Icon { get; set; }

        public int TargetFPS { get; set; }

        public int TargetFPSIdle { get; set; }

        public string? StreamUrl { get; set; }

        public string? SnapshotUrl { get; set; }

        public bool FlipHorizontal { get; set; }

        public bool FlipVertical { get; set; }

        public int Rotation { get; set; }

        public string? AspectRatio { get; set; }

        public object? ExtraData { get; set; }

        public string? Source { get; set; }

        public string? Uid { get; set; }
    }
}