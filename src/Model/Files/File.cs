namespace PowerRaker.Model.Files
{

    public class File
    {
        public string? Path { get; set; }
        public string? Root { get; set; }

        public DateTime? Modified { get; set; }
        public int Size { get; set; }
        public string? Permissions { get; set; }

    }
}