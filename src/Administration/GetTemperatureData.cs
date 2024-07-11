using System.Management.Automation;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "TemperatureData")]
    public class GetTemperatureData : KlipperCmdlet
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