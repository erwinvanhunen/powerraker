using System.Management.Automation;
using System.Text.Json;

namespace powerraker
{

    [Cmdlet(VerbsCommon.Get, "GCodeMetadata")]
    public class GetGCodeMetadata : RakerCmdlet
    {
        [Parameter(Mandatory = true)]
        public required string Name { get; set; }

        protected override void ExecuteCmdlet()
        {
            var output = RestHelper.ExecuteGetRequest(this.Connection, $"/server/files/metadata?filename={Name}");

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new UnixToNullableDateTimeConverter());
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output, options);
            if (jsonDocument != null)
            {
                var files = JsonSerializer.Deserialize<model.files.Metadata>(jsonDocument.RootElement.GetProperty("result"), options);
                WriteObject(files, true);
            }
        }
    }

}