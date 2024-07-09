using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, "ExtruderStatus")]
    public class ExtruderStatus : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Extended { get; set; }

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
                    WriteObject(extruder);
                }
            }
        }
    }
}
