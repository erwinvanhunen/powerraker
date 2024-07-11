using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "Sensor")]
    public class GetSensor : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter Extended { get; set; }

        protected override void ExecuteCmdlet()
        {
            try
            {
                var result = GetResult<Sensor>($"/server/sensors/list?extended={(Extended ? "True" : "False")}");
                WriteObject(result);
            }
            catch (Exception)
            {

                WriteWarning($"No sensors found. Did you configure [sensor] component? Use Get-{PREFIX}Temperature to retrieve the temperature status.");
            }

        }
    }
}