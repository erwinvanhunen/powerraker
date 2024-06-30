using System.ComponentModel.Design.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace powerraker.model.files
{

    public class FileRoot
    {
        public string? Name { get; set; }

        public string? Path { get; set; }

        public string? Permissions { get; set; }

        public static List<FileRoot>? GetRoots(RakerConnection connection)
        {
            var output = RestHelper.ExecuteGetRequest(connection, $"/server/files/roots");

            var options = new JsonSerializerOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;

            List<FileRoot>? roots = null;
            var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(output, options);
            if (jsonDocument != null)
            {
                roots = jsonDocument.RootElement.GetProperty("result").Deserialize<List<model.files.FileRoot>>(options);
            }
            return roots;
        }
    }
}