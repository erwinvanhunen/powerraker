using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Set, PREFIX + "PrintFlow")]
    public class SetPrintFlow : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public int? Percentage { get; set; }


        protected override void ExecuteCmdlet()
        {
            SendGCode($"M221 S{Percentage}");
        }
    }
}

