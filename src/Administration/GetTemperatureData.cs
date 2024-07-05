using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, "TemperatureData")]
    public class GetTemperatureData : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeMonitors;
        protected override void ExecuteCmdlet()
        {
            var tempInfo = GetResult<Dictionary<string, Dictionary<string, List<double>>>>($"/server/temperature_store?include_monitors={(IncludeMonitors ? "true" : "false")}");
            WriteObject(tempInfo);
        }
    }
}