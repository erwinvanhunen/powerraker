namespace powerraker.administration
{
    public class ServerInfo
    {
        public bool KlippyConnected { get; set; }

        public string? KlippyState { get; set; }

        public List<string>? Components { get; set; }

        public List<string>? FailedComponents { get; set; }

        public List<string>? RegisteredDirectories { get; set; }

        public List<string>? Warnings { get; set; }

        public int WebsocketCount { get; set; }

        public string? MoonRakerVersion { get; set; }

        public List<int>? ApiVersion { get; set; }

        public string? ApiVersionString { get; set; }
    }
}