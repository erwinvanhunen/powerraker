using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Set, PREFIX + "PrinterLimit")]
    public class SetPrinterLimit : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public int? Velocity { get; set; }

        [Parameter(Mandatory = false)]
        public int? SquareCornerVelocity { get; set; }

        [Parameter(Mandatory = false)]
        public int? Acceleration { get; set; }

        [Parameter(Mandatory = false)]
        public int? AccelToDecel { get; set; }

        protected override void ExecuteCmdlet()
        {
            List<string> gcodes = new List<string>();
            if (ParameterSpecified(nameof(Velocity)))
            {
                gcodes.Add($"SET_VELOCITY_LIMIT VELOCITY={Velocity}");
            }
            if (ParameterSpecified(nameof(SquareCornerVelocity)))
            {
                gcodes.Add($"SET_VELOCITY_LIMIT SQUARE_CORNER_VELOCITY={SquareCornerVelocity}");
            }
            if (ParameterSpecified(nameof(Acceleration)))
            {
                gcodes.Add($"SET_VELOCITY_LIMIT ACCEL={Acceleration}");
            }
            if (ParameterSpecified(nameof(AccelToDecel)))
            {
                gcodes.Add($"SET_VELOCITY_LIMIT ACCEL_TO_DECEL={AccelToDecel}");
            }

            foreach (var gcode in gcodes)
            {
                var result = SendGCode(gcode);
                if (result != "ok")
                {
                    WriteObject($"Setting {gcode} failed");
                }
            }
        }
    }
}

