using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.administration
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