using System.Management.Automation;

namespace PowerRaker.gcode
{

    [Cmdlet(VerbsLifecycle.Invoke, "GCode")]
    public class InvokeGCode : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Code { get; set; }
        protected override void ExecuteCmdlet()
        {
            var result = PostResult<string>($"/printer/gcode/script?script={Code}");
            WriteObject(result);
        }
    }
}