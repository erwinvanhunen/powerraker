using System.Management.Automation;
using PowerRaker.Model.Administration;

namespace PowerRaker.Administration
{

    [Cmdlet(VerbsCommon.Get, "Accessinfo")]
    public class GetAccessInfo : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var accessInfo = GetResult<AccessInfo>("/access/info");
            WriteObject(accessInfo);

        }
    }

}