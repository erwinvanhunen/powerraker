using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.gcode
{

    [Cmdlet(VerbsCommon.Get, "GCodeHelp")]
    public class GetGCodeHelp : RakerCmdlet
    {
     
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<Dictionary<string,string>>($"/printer/gcode/help");
            WriteObject(result);
        }
    }
}