using System.Management.Automation;

namespace PowerRaker.Files
{

    [Cmdlet(VerbsCommon.Get, PREFIX + "File")]
    public class GetFile : KlipperCmdlet
    {
        const string Param_FOLDER = "Folder";
        const string Param_FILE = "File";

        [Parameter(Mandatory = false, ParameterSetName = Param_FOLDER)]
        public string Folder { get; set; } = "gcodes";

        [Parameter(Mandatory = true, ParameterSetName = Param_FILE)]
        public required string Filename { get; set; }

        protected override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case Param_FOLDER:
                    {

                        var files = GetResult<List<Model.Files.File>>($"/server/files/list?root={Folder}");
                        WriteObject(files, true);
                        break;
                    }

                case Param_FILE:
                    {
                        var bytes = GetBinaryResult($"/server/files/{Filename}");
                        var fileInfo = new FileInfo(Filename);
                        var outName = fileInfo.Name;
                        if (!System.IO.Path.IsPathRooted(outName))
                        {
                            outName = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, outName);
                        }
                        System.IO.File.WriteAllBytes(outName, bytes);
                        break;
                    }
            }

        }
    }

}