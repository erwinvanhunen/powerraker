using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "ServerInfo")]
    public class GetServerInfo : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var serverInfo = GetResult<ServerInfo>("/server/info");
            WriteObject(serverInfo);
        }
    }
}