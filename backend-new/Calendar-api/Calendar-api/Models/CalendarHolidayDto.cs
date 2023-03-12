namespace Calendar_api.Models
{
    public class CalendarHolidayDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CalendarId { get; set; }
        public int ColorId { get; set; }
        public string? CalendarColorBackgroundColor { get; set; }
        public string? CalendarColorFontColor { get; set; }
        public int EmojiId { get; set; }
        public string? EmojiEmoticon { get; set; }
        public bool IsRepeatedYearly { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int? Year { get; set; }

        public CalendarHolidayDto(int id, string title, string description,
             int calendarId, int calendarColorId, string calendarColorBackgroundColor,
             int emojiId, string emojiEmoticon, bool isRepeatedYearly,
             int day, int month, int? year, string? calendarColorFontColor)
        {
            Id = id;
            Title = title;
            Description = description;
            CalendarId = calendarId;
            ColorId = calendarColorId;
            CalendarColorBackgroundColor = calendarColorBackgroundColor;
            CalendarColorFontColor = calendarColorFontColor;
            EmojiId = emojiId;
            EmojiEmoticon = emojiEmoticon;
            this.IsRepeatedYearly = isRepeatedYearly;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
