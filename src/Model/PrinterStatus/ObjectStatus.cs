namespace PowerRaker.Model.PrinterStatus
{
    public class ObjectStatus<T>
    {
        public DateTime? EventTime { get; set; }
        public Dictionary<string, T>? Status { get; set; }
    }

    public class Toolhead
    {
        public string? HomedAxes { get; set; }
        public double[]? AxisMinimum { get; set; }
        public double[]? AxisMaximum { get; set; }
        public DateTime? PrintTime { get; set; }
        public int Stalls { get; set; }
        public DateTime? EstimatedPrintTime { get; set; }
        public string? Extruder { get; set; }
        public double[]? Position { get; set; }
        public double? MaxVelocity { get; set; }
        public double? MaxAccel { get; set; }
        public double? MinimumCruiseRatio { get; set; }
        public double? SquareCornerVelocity { get; set; }

    }

    public class Extruder
    {
        public double? Temperature { get; set; }
        public double? Target { get; set; }
        public double? Power { get; set; }
        public bool? CanExtrude { get; set; }
        public double? PressureAdvance { get; set; }
        public double? SmoothTime { get; set; }
    }

    public class Heaters
    {
        public List<string>? AvailableHeaters { get; set; }
        public List<string>? AvailableSensors { get; set; }
        public List<string>? AvailableMonitors { get; set; }
    }

    public class TemperatureSensor
    {
        public double? Temperature { get; set; }
    }
}