using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Stop, "Printer")]

    public class StopPrinter : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/emergency_stop");
            WriteObject(result);
        }
    }
}