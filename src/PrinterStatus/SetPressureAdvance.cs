using System.Globalization;
using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Set, PREFIX + "PressureAdvance")]
    public class SetPressureAdvance : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public double Advance { get; set; }

        [Parameter(Mandatory = false)]
        public double SmoothTime { get; set; }


        protected override void ExecuteCmdlet()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            var values = new List<string>();
            if (ParameterSpecified(nameof(SmoothTime)))
            {
                values.Add($"SMOOTH_TIME={SmoothTime.ToString(nfi)}");
            }
            if (ParameterSpecified(nameof(Advance)))
            {
                values.Add($"ADVANCE={Advance.ToString(nfi)}");
            }
            SendGCode($"SET_PRESSURE_ADVANCE {(string.Join(' ', values))}");
        }
    }
}
