using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class CalendarTaskService
    {
        private readonly DataContext _context;
        private static CalendarTaskService _instance;
        private CalendarTaskService(DataContext context)
        {
            _context = context;
        }
        public static CalendarTaskService GetInstance(DataContext context)
        {
            if (_instance == null)
            {
                _instance = new CalendarTaskService(context);
            }
            return _instance;
        }

        public async Task AddBook(CalendarTask calendarTask)
        {
            _context.CalendarTask.Add(calendarTask);
            await _context.SaveChangesAsync();
        }

    }
}
