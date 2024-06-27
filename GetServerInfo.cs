using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "ServerInfo")]
    public class GetServerInfo : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var output = RestHelper.ExecuteGetRequest(this.Connection, "/server/info");
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output);
            var jobs = jsonDocument.RootElement.GetProperty("result");

            WriteObject(jobs.Deserialize<ServerInfo>(), true);
        }
    }

}