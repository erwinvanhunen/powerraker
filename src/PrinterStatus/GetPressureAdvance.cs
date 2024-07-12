using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "PressureAdvance")]
    public class GetPressureAdvance : KlipperCmdlet
    {

        protected override void ExecuteCmdlet()
        {
            var statusResult = GetResult<ObjectStatus<Toolhead?>>("/printer/objects/query?toolhead");
            statusResult.Status.TryGetValue("toolhead", out Toolhead? toolhead);
            if (toolhead != null)
            {
                var extruderName = toolhead.Extruder;

                var result = GetResult<ObjectStatus<Extruder?>>($"/printer/objects/query?{extruderName}");
                result.Status.TryGetValue("extruder", out Extruder? extruder);
                if (extruder != null)
                {
                    WriteObject(new { extruder.PressureAdvance, extruder.SmoothTime });
                }
            }
        }
    }
}
