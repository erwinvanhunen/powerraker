using System.ComponentModel.Design.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PowerRaker.Model.Files
{
    public class FileRoot
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Permissions { get; set; }
    }
}