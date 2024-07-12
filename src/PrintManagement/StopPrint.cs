using System.Management.Automation;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Stop, PREFIX + "Print")]
    public class StopPrint : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue($"Cancel current print?", "Cancel"))
            {
                var result = PostResult<string>($"/printer/print/cancel");
                WriteObject(result);
            }
        }
    }
}