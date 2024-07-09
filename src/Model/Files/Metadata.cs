namespace PowerRaker.Model.Files
{
    public class Metadata
    {

        public string? Filename { get; set; }
        public string? JobId { get; set; }
        public DateTime? PrintStartTime { get; set; }
        public int Size { get; set; }
        public DateTime? Modified { get; set; }
        public string? Slicer { get; set; }
        public string? SlicerVersion { get; set; }
        public int GcodeStartByte { get; set; }

        public int GcodeEndByte { get; set; }
        public int LayerCount { get; set; }
        public double ObjectHeight { get; set; }
        public int EstimatedTime { get; set; }
        public double NozzleDiameter { get; set; }
        public double LayerHeight { get; set; }
        public double FirstLayerHeight { get; set; }
        public double FirstLayerExtrTemp { get; set; }
        public double FirstLayerBedTemp { get; set; }
        public double ChamberTemp { get; set; }
        public string? FilamentName { get; set; }
        public string? FilamentType { get; set; }
        public double FilamentTotal { get; set; }

        public List<Thumbnail>? Thumbnails { get; set; }

    }
}