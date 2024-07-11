using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Stop, PREFIX + "Printer")]

    public class StopPrinter : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/emergency_stop");
            WriteObject(result);
        }
    }
}