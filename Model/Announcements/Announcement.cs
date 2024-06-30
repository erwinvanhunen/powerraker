namespace powerraker.announcements
{
    public class Announcement
    {
        public string? EntryId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public DateTime? Date { get; set; }
        public bool Dismissed { get; set; }
        public DateTime? DateDismissed { get; set; }
        public string? Source { get; set; }
        public string? Feed { get; set; }
    }

}