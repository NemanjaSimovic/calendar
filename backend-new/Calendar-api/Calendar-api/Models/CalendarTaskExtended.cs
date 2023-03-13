namespace Calendar_api.Models
{
    public class CalendarTaskExtended
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public int CalendarId { get; set; }
        public string? CalendarName { get; set; }

        public List<int> ParticipantIds { get; set; }
        public List<string>? ParticipantNames { get; set; }

        public int CreatorId { get; set; }
        public string? CreatorName { get; set; }

        public int CalendarColorId { get; set; }
        public string? CalendarColorBackgroundColor { get; set; }
        public string? CalendarColorFontColor { get; set; }

        public int EmojiId { get; set; } = 0;
        public string? EmojiEmoticon { get; set; }

        public bool IsNotWorkingHoliday { get; set; }

        public bool KnownForEveryone { get; set; }
        public string? CaptionForEveryone { get; set; }
        public string? DescriptionForEveryone { get; set; }

        public CalendarTaskExtended(int id, string title, string description,
            DateTime startTime, DateTime endTime, int calendarId, string calendarName,
            List<int> participantIds, List<string> participantNames, int creatorId, string creatorName,
            int calendarColorId, string calendarColorBackgroundColor, int emojiId, string emojiEmoticon,
            bool isNotWorkingHoliday, bool knownForEveryone, string? calendarColorFontColor, string? captionForEveryone,
            string? descriptionForEveryone)

        {
            Id = id;
            Title = title;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            CalendarId = calendarId;
            CalendarName = calendarName;
            ParticipantIds = participantIds;
            ParticipantNames = participantNames;
            CreatorId = creatorId;
            CreatorName = creatorName;
            CalendarColorId = calendarColorId;
            CalendarColorBackgroundColor = calendarColorBackgroundColor;
            CalendarColorFontColor = calendarColorFontColor;
            EmojiId = emojiId;
            EmojiEmoticon = emojiEmoticon;
            IsNotWorkingHoliday = isNotWorkingHoliday;
            KnownForEveryone = knownForEveryone;
            CaptionForEveryone = captionForEveryone;
            DescriptionForEveryone = descriptionForEveryone;
        }
    }
}
