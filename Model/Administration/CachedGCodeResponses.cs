namespace PowerRaker.Model.Administration
{
    public class CachedGCodeResponses
    {
        public List<GcodeReponseCommand>? GcodeStore
        {
            get; set;
        }
    }

    public class GcodeReponseCommand
    {
        public DateTime? Time { get; set; }
        public string? Type { get; set; }
        public string? Message { get; set; }


    }
}
