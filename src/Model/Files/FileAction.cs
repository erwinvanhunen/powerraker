using System.Management.Automation.Provider;

namespace PowerRaker.Model.Files
{
    public class FileAction
    {
        public File? Item { get; set; }
        public string? Action { get; set; }
        public bool? PrintStarted { get; set; }
        public bool? PrintQueued { get; set; }
    }

}