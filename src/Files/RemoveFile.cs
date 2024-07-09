using System.Management.Automation;
using PowerRaker.Model.Files;

namespace PowerRaker
{

    public enum RootFolder
    {
        GCodes,
        Config
    }

    [Cmdlet(VerbsCommon.Remove, "File")]
    public class RemoveFile : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Filename { get; set; }

        public required RootFolder RootFolder { get; set; } = RootFolder.GCodes;
        protected override void ExecuteCmdlet()
        {
            var fileAction = DeleteResult<FileAction>($"/server/files/{RootFolder.ToString().ToLower()}/{Filename}");
            WriteObject(fileAction);
        }
    }
}