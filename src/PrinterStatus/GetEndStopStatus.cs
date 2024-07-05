using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
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