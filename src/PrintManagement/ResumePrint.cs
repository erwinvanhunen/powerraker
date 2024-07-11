using System.Management.Automation;

namespace PowerRaker.printmanagement
{

    [Cmdlet(VerbsLifecycle.Resume, PREFIX + "Print")]
    public class ResumePrint : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/print/resume");
            WriteObject(result);
        }
    }
}