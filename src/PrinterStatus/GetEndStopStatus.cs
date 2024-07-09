using System.Management.Automation;
using PowerRaker.Model.PrinterStatus;

namespace PowerRaker.PrinterStatus
{

    [Cmdlet(VerbsCommon.Get, "EndStopStatus")]
    public class GetEndStopStatus : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<EndStopStatus>("/printer/query_endstops/status");
            WriteObject(result);
        }
    }
}