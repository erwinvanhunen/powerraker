using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Model.Files;

namespace PowerRaker.Files
{

    [Cmdlet(VerbsCommon.Get, "FileRoots")]
    public class GetFileRoots : RakerCmdlet
    {
        protected override void ExecuteCmdlet()
        {
            var roots = GetResult<List<FileRoot>>("/server/files/roots");
            if (roots != null)
            {
                WriteObject(roots, true);
            }
        }
    }

}