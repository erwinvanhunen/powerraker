using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Suspend, "Print")]
    public class SuspendPrint : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/pause");
            WriteObject(result);
        }
    }
}