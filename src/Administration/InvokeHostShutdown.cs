using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsLifecycle.Invoke, PREFIX + "HostShutdown")]
    public class InvokeHostShutdown : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            PostResult<string>("/machine/shutdown");
        }
    }

}