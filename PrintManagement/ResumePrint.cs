using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Resume, "Print")]
    public class ResumePrint : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/resume");
            WriteObject(result);
        }
    }
}