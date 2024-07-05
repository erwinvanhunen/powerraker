namespace PowerRaker.Model.Job
{
    public class PrinterObjectsQuery
    {
        public DateTime? Eventtime { get; set; }
        public PrinterObjectsQueryStatus? Status { get; set; }
    }

    public class PrinterObjectsQueryStatus
    {
        public PrintStats? PrintStats {get;set;}
        public VirtualSDCard? VirtualSdcard {get;set;}
    }

    public class PrintStats
    {
        public string? Filename { get; set; }
        public double? TotalDuration { get; set; }
        public double? PrintDuration { get; set; }
        public double? FilamentUsed { get; set; }
        public string? State { get; set; }
        public string? Message { get; set; }
        public PrintStatsInfo? Info { get; set; }
        public int PowerLoss { get; set; }

        public double? ZPos { get; set; }
    }

    public class PrintStatsInfo
    {
        public double? TotalLayer { get; set; }
        public double? CurrentLayer { get; set; }
    }

    public class VirtualSDCard
    {
        public string? FilePath { get; set; }
        public double Progress { get; set; }
        public bool IsActivate { get; set; }
        public int? FilePosition { get; set; }
        public int? FileSize { get; set; }
        public bool FirstLayerStop { get; set; }
        public int? Layer { get; set; }
        public int? LayerCount { get; set; }
        public double? RunDis { get; set; }
    }
}