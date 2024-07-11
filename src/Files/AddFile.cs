using System.Management.Automation;
using PowerRaker.Model.Files;

namespace PowerRaker.Files
{

    public enum TargetFolder
    {
        GCodes,
        Config
    }

    [Cmdlet(VerbsCommon.Add, PREFIX + "File")]
    public class AddFile : KlipperCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Filename { get; set; }

        public required TargetFolder TargetFolder { get; set; } = TargetFolder.GCodes;
        protected override void ExecuteCmdlet()
        {

            if (!Path.IsPathRooted(Filename))
            {
                Filename = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Filename);
            }
            if (System.IO.File.Exists(Filename))
            {
                var fileData = System.IO.File.ReadAllBytes(Filename);
                var fileInfo = new FileInfo(Filename);
                var result = PostMultiformData<FileAction>($"/server/files/upload", fileInfo.Name, fileData);
                WriteObject(result);
            }
        }
    }
}