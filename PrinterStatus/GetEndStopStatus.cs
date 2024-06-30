using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using powerraker.model.printerstatus;

namespace powerraker.printerstatus
{

    [Cmdlet(VerbsCommon.Get, "EndStopStatus")]
    public class GetEndStopStatus : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<EndStopStatus>("/printer/query_endstops/status");
            WriteObject(result);
        }
    }
}