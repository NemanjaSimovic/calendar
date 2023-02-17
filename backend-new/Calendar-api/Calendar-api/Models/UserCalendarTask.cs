namespace Calendar_api.Models
{
    public class UserCalendarTask
    {
        public int Id { get; set; }
        public int CalendarTaskId { get; set; }
        public int userId { get; set; }

        public UserCalendarTask(int calendarTaskId, int userId)
        {
            CalendarTaskId = calendarTaskId;
            this.userId = userId;
        }
    }
}
