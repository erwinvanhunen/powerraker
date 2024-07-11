using System.Management.Automation;
using PowerRaker.Model.Files;

namespace PowerRaker.Files
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "FileMetadata")]
    public class GetFileMetadata : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            var metadata = GetResult<Metadata>($"/server/files/metadata?filename={Name}");
            WriteObject(metadata);

        }
    }

}