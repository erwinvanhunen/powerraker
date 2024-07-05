using System.Management.Automation;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, "Sensor")]
    public class GetSensor : RakerCmdlet
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