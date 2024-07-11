using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Set, PREFIX + "PrintSpeed")]
    public class SetPrintSpeed : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public int? Percentage { get; set; }


        protected override void ExecuteCmdlet()
        {
            SendGCode($"M220 S{Percentage}");
        }
    }
}

