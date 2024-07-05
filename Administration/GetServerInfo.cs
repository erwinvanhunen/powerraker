using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, "ServerInfo")]
    public class GetServerInfo : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var serverInfo = GetResult<ServerInfo>("/server/info");
            WriteObject(serverInfo);
        }
    }
}