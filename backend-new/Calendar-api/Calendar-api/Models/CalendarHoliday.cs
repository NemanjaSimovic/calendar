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
        public int? EmojiId { get; set; }
        public bool Overlapable { get; set; }
    }
}
