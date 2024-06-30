using System.Management.Automation;

namespace powerraker.administration
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