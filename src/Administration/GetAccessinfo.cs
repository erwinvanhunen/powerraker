using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "Accessinfo")]
    public class GetAccessInfo : KlipperCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var accessInfo = GetResult<AccessInfo>("/access/info");
            WriteObject(accessInfo);

        }
    }

}