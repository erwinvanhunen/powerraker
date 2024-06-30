using System.Management.Automation;

namespace powerraker.administration
{
    [Cmdlet(VerbsLifecycle.Restart, "Printer")]

    public class RestartPrinter : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/restart");
            WriteObject(result);
        }
    }
}