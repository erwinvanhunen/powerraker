using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using powerraker.model.printerstatus;

namespace powerraker.gcode
{

    [Cmdlet(VerbsLifecycle.Invoke, "GCode")]
    public class InvokeGCode : RakerCmdlet
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