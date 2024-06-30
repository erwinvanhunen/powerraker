using System.Management.Automation;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "File")]
    public class GetFile : RakerCmdlet
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
                        var output = RestHelper.ExecuteGetRequest(this.Connection, $"/server/files/list?root={Folder}");

                        JsonSerializerOptions options = new JsonSerializerOptions();
                        options.Converters.Add(new UnixToNullableDateTimeConverter());
                        options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

                        var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output, options);
                        if (jsonDocument != null)
                        {
                            var files = JsonSerializer.Deserialize<List<model.files.File>>(jsonDocument.RootElement.GetProperty("result"), options);
                            WriteObject(files, true);
                        }
                        break;
                    }

                case Param_FILE:
                    {
                        var bytes = RestHelper.ExecuteGetRequestBinary(Connection, $"/server/files/{Filename}");
                        var fileInfo = new FileInfo(Filename);
                        var outName = fileInfo.Name;
                        if (!System.IO.Path.IsPathRooted(outName))
                        {
                            Filename = System.IO.Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, outName);
                        }
                        System.IO.File.WriteAllBytes(outName, bytes);
                        break;
                    }
            }

        }
    }

}