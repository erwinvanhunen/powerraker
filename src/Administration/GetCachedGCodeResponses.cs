using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{
    [Cmdlet(VerbsCommon.Get, PREFIX + "CachedGCodeResponses")]
    public class GetCachedGCodeResponses : KlipperCmdlet
    {
        [Parameter(Mandatory = false)]
        public int Count = 100;
        protected override void ExecuteCmdlet()
        {
            var result = GetResult<CachedGCodeResponses>($"/server/gcode_store?count={Count}");
            if (result != null)
            {
                WriteObject(result.GcodeStore);
            }
        }
    }
}