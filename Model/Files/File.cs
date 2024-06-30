using System.Text.Json.Serialization;

namespace powerraker.model.files
{

    public class File {
        public string? Path {get;set;}
        public DateTime? Modified {get;set;}
        public int Size {get;set;}
        public string? Permissions {get;set;}
    }
}