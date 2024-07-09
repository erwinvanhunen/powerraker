using System.Management.Automation;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Start, "Print")]
    public class StartPrintFile : KlipperCmdlet
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