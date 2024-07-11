using System.Management.Automation;
using PowerRaker.Model.Files;

namespace PowerRaker.Files
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "FileRoots")]
    public class GetFileRoots : KlipperCmdlet
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