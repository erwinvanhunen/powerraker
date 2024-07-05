using System.IO.Enumeration;
using System.Management.Automation;
using System.Text.Json;
using PowerRaker.Model.Files;

namespace PowerRaker.Files
{

    public enum TargetFolder
    {
        GCodes,
        Config
    }

    [Cmdlet(VerbsCommon.Add, "File")]
    public class AddFile : RakerCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Filename { get; set; }

        public required TargetFolder TargetFolder {get;set;} = TargetFolder.GCodes;
        protected override void ExecuteCmdlet()
        {
            
            if (!Path.IsPathRooted(Filename))
            {
                Filename = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, Filename);
            }
            var fileData = System.IO.File.ReadAllBytes(Filename);
            var fileInfo = new FileInfo(Filename);
            var result = RestHelper.ExecutePostMultiformData(this.Connection,$"/server/files/upload",$"{fileInfo.Name}",fileData);
            WriteObject(result);
        }
    }
}