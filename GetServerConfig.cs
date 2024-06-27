using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "ServerConfig")]
    public class GetServerConfig : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

            var output = RestHelper.ExecuteGetRequest(this.Connection, "/server/config");
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output,options);
            var jobs = jsonDocument.RootElement.GetProperty("result");
            WriteObject(jobs.Deserialize<Server>(options));
        }
    }

}