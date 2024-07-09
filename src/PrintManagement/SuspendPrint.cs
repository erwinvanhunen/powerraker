using System.Management.Automation;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Suspend, "Print")]
    public class SuspendPrint : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/pause");
            WriteObject(result);
        }
    }
}