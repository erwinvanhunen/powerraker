using System.Management.Automation;
using System.Text.Json.Serialization;

namespace powerraker
{
    public class ServerInfo
    {
        [JsonPropertyName("klippy_connected")]
        public bool KlippyConnected { get; set; }
        [JsonPropertyName("klippy_state")]
        public string KlippyState { get; set; }
        [JsonPropertyName("components")]
        public List<string> Components { get; set; }
        [JsonPropertyName("failed_components")]
        public List<string> FailedComponents { get; set; }
        [JsonPropertyName("registered_directories")]
        public List<string> RegisteredDirectories { get; set; }
        [JsonPropertyName("warnings")]
        public List<string> Warnings { get; set; }
        [JsonPropertyName("websocket_count")]
        public int WebsocketCount { get; set; }
        [JsonPropertyName("moonraker_version")]
        public string MoonRakerVersion { get; set; }
        [JsonPropertyName("api_version")]
        public List<int> ApiVersion { get; set; }
        [JsonPropertyName("api_version_string")]
        public string ApiVersionString { get; set; }
    }
}