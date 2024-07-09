namespace PowerRaker.Model.Administration
{
    public class LogRolloverResult
    {
        public List<string>? RolledOver { get; set; }
        public Dictionary<string, string>? Failed { get; set; }
    }
}