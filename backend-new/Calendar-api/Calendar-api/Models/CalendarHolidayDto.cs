namespace Calendar_api.Models
{
    public class CalendarHolidayDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int CalendarId { get; set; }
        public int ColorId { get; set; }
        public string? CalendarColorBackgroundColor { get; set; }
        public string? CalendarColorFontColor { get; set; }
        public int EmojiId { get; set; }
        public string? EmojiEmoticon { get; set; }

        public CalendarHolidayDto(int id, string title, string description,
            int day, int month, int calendarId, int calendarColorId,
            string calendarColorBackgroundColor, int emojiId,
            string emojiEmoticon, string? calendarColorFontColor)
        {
            Id = id;
            Title = title;
            Description = description;
            Day = day;
            Month = month;
            CalendarId = calendarId;
            ColorId = calendarColorId;
            CalendarColorBackgroundColor = calendarColorBackgroundColor;
            CalendarColorFontColor = calendarColorFontColor;
            EmojiId = emojiId;
            EmojiEmoticon = emojiEmoticon;
        }
    }
}
