using System.Data.Common;
using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker;

[Cmdlet(VerbsCommunications.Disconnect, "Printer")]
public class DisconnectPrinter : RakerCmdlet
{
    protected override void ExecuteCmdlet()
    {
        if (this.Connection.IsTokenAuth())
        {
            var authInfo = PostResult<AuthInfo>("/access/logout");
            if (authInfo.Action == "user_logged_out")
            {
                WriteObject($"User {authInfo.Username} logged out. User Connect-KlipperPrinter to reconnect.");
            }
        }
        RakerConnection.Current = null;

    }
}
