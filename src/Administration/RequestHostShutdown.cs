using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsLifecycle.Request, PREFIX + "HostShutdown")]
    public class RequestHostShutdown : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue($"Shutdown Host?", "Shutdown"))
            {
                PostResult<string>("/machine/shutdown");
            }
        }

    }
}