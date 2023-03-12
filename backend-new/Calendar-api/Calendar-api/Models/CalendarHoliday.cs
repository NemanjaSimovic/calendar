namespace Calendar_api.Models
{
    public class CalendarHoliday
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CalendarId { get; set; }
        public int CalendarColorId { get; set; }
        public int EmojiId { get; set; }
        public bool IsRepeatedYearly { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int? Year { get; set; }

        public CalendarHoliday(string title, string description,
        int calendarId, int calendarColorId, int emojiId,
        bool isRepeatedYearly, int day, int month, int? year)
        {
            Title = title;
            Description = description;
            CalendarId = calendarId;
            CalendarColorId = calendarColorId;
            EmojiId = emojiId;
            IsRepeatedYearly = isRepeatedYearly;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
