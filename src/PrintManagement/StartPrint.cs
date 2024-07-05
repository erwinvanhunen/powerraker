using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Start, "Print")]
    public class StartPrintFile : RakerCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Filename {get;set;}
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/start?filename={Filename}");
            WriteObject(result);
        }
    }
}