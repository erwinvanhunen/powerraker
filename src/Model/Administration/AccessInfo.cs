namespace PowerRaker.Model.Administration
{
    public class AccessInfo
    {
        public string? DefaultSource { get; set; }
        public List<string>? AvailableSources { get; set; }
        public bool LoginRequired {get;set;}
        public bool Trusted {get;set;}
    }
}