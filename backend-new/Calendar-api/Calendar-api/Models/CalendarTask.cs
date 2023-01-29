namespace Calendar_api.Models
{
    public class CalendarTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CalendarId { get; set; }
        public int CreatorId { get; set; }
        public int CalendarColorId { get; set; }
        public int? EmojiId { get; set; }
        public bool KnownForEveryone { get; set; }
        public string? CaptionForEveryone { get; set; }
        public string? DescriptionForEveryone { get; set; }

    }
}
