namespace PowerRaker.Model.PrinterStatus
{
    public class Sensor
    {
        public string? Id { get; set; }
        public string? FriendlyName { get; set; }
        public string? Type { get; set; }
        public Dictionary<string,Dictionary<string,double>>? Values {get;set;}
        public Dictionary<string,string>? ParameterInfo {get;set;}
        public Dictionary<string,string>? HistoryFields {get;set;}
    }
}