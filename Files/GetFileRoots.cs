using System.Management.Automation;
using System.Text.Json;
using powerraker.model.files;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "FileRoots")]
    public class GetFileRoots : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var roots = FileRoot.GetRoots(this.Connection);
            if(roots != null)
            {
                WriteObject(roots, true);
            }
        }
    }

}