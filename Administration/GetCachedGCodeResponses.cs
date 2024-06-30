using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace powerraker.administration
{

    [Cmdlet(VerbsCommon.Get, "CachedGCodeResponses")]
    public class GetCachedGCodeResponses : RakerCmdlet
    {
        [Parameter(Mandatory = false)]
        public int Count = 100;
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<List<GcodeReponseCommand>>($"/server/gcode_store?count={Count}", "gcode_store");
            WriteObject(result);
        }
    }
}