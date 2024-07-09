using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, "Sensor")]
    public class GetSensor : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Extended {get;set;}

        protected override void ExecuteCmdlet()
        {
            var result = GetResult<Sensor>($"/server/sensors/list?extended={(Extended ? "true": "false")}");
            WriteObject(result);
        }
    }
}