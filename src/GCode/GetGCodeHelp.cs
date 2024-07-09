using System.Management.Automation;

namespace PowerRaker.gcode
{

    [Cmdlet(VerbsCommon.Get, "GCodeHelp")]
    public class GetGCodeHelp : KlipperCmdlet
    {
     
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<Dictionary<string,string>>($"/printer/gcode/help");
            WriteObject(result);
        }
    }
}