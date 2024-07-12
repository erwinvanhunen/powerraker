using System.Diagnostics;
using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsLifecycle.Request, PREFIX + "HostReboot")]
    public class RequestHostReboot : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }
        
        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue($"Reboot Host?", "Reboot"))
            {
                PostResult<string>("/machine/reboot");
            }
        }
    }

}