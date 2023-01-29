using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class UserCalendarTaskService
    {
        private readonly DataContext _context;
        private static UserCalendarTaskService _instance;
        private UserCalendarTaskService(DataContext context)
        {
            _context = context;
        }
        public static UserCalendarTaskService GetInstance(DataContext context)
        {
            if (_instance == null)
            {
                _instance = new UserCalendarTaskService(context);
            }
            return _instance;
        }

        public async Task<List<UserCalendarTask>> GetAllByCalendarTaskAsync(int calendarTaskId)
        {
            return await _context.UserCalendarTask.Where(u => u.CalendarTaskId == calendarTaskId).ToListAsync();
        }


    }
}
