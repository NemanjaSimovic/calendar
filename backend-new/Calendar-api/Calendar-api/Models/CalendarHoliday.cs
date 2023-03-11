namespace Calendar_api.Models
{
    public class CalendarHoliday
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int CalendarId { get; set; }
        public int ColorId { get; set; }
        public int EmojiId { get; set; }

        public CalendarHoliday(string title, string description,
        int day, int month, int calendarId, int colorId, int emojiId)
        {
            Title = title;
            Description = description;
            Day = day;
            Month = month;
            CalendarId = calendarId;
            ColorId = colorId;
            EmojiId = emojiId;
        }
    }
}
