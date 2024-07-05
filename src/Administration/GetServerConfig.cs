using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
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