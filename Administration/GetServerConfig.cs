using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.administration
{

    [Cmdlet(VerbsCommon.Get, "ServerConfig")]
    public class GetServerConfig : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var serverConfig = GetResult<Server>("/server/config");
            WriteObject(serverConfig);

        }
    }

}