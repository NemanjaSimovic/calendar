namespace Calendar_api.Models
{
    public class CalendarHoliday
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ApplyToEveryone { get; set; }
        public int userId { get; set; }
        public int CalendarId { get; set; }
        public int ColorId { get; set; }
        public int EmojiId { get; set; }
        public bool Working { get; set; }

        public CalendarHoliday(int id, string title, string description, DateTime startdate, DateTime endDate, bool applyToEveryone, int userId, int calendarId, int colorId, int emojiId, bool working)
        {
            Id = id;
            Title = title;
            Description = description;
            Startdate = startdate;
            EndDate = endDate;
            ApplyToEveryone = applyToEveryone;


            this.userId = userId;
            CalendarId = calendarId;
            ColorId = colorId;
            EmojiId = emojiId;
            Working = working;
        }
    }
}
