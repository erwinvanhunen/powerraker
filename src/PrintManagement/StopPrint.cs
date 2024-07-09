using System.Management.Automation;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Stop, "Print")]
    public class StopPrint : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/cancel");
            WriteObject(result);
        }
    }
}