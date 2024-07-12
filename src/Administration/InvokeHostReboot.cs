using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsLifecycle.Invoke, PREFIX + "HostReboot")]
    public class InvokeHostReboot : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            PostResult<string>("/machine/reboot");
        }
    }

}