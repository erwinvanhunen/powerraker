using System.IO.Enumeration;
using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Model.Files;

namespace PowerRaker
{

    public enum RootFolder
    {
        GCodes,
        Config
    }

    [Cmdlet(VerbsCommon.Remove, "File")]
    public class RemoveFile : RakerCmdlet
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