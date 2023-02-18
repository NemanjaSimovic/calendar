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
        public int EmojiId { get; set; } = 0;
        public bool KnownForEveryone { get; set; }
        public string? CaptionForEveryone { get; set; }
        public string? DescriptionForEveryone { get; set; }

        public CalendarTask(string title, string description, DateTime startTime, DateTime endTime, int calendarId, int creatorId, int calendarColorId, int emojiId, bool knownForEveryone, string? captionForEveryone, string? descriptionForEveryone)
        {
            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            CalendarId = calendarId;
            CreatorId = creatorId;
            CalendarColorId = calendarColorId;
            EmojiId = emojiId;
            KnownForEveryone = knownForEveryone;
            CaptionForEveryone = captionForEveryone ?? "";
            DescriptionForEveryone = descriptionForEveryone ?? "";
        }
    }
}
