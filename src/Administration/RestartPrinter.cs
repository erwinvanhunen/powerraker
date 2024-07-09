using System.Management.Automation;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsLifecycle.Restart, "Printer")]

    public class RestartPrinter : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>("/printer/restart");
            WriteObject(result);
        }
    }
}