using System.Management.Automation;
using PowerRaker.Model.Users;

namespace PowerRaker;

[Cmdlet(VerbsCommunications.Disconnect, "Printer")]
public class DisconnectPrinter : KlipperCmdlet
{
    protected override void ExecuteCmdlet()
    {
        if (this.Context.IsTokenAuth())
        {
            var authInfo = PostResult<AuthInfo>("/access/logout");
            if (authInfo.Action == "user_logged_out")
            {
                WriteObject($"User {authInfo.Username} logged out. User Connect-KlipperPrinter to reconnect.");
            }
        }
        PrinterContext.Current = null;

    }
}
