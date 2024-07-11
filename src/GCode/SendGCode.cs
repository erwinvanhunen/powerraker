using System.Management.Automation;

namespace PowerRaker.gcode
{

    [Cmdlet(VerbsCommunications.Send, PREFIX + "GCode")]
    public class SendGCode : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Code { get; set; }
        protected override void ExecuteCmdlet()
        {
            SendGCode(Code);
        }
    }
}