using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class CalendarTaskService
    {
        private readonly DataContext _context;
        public CalendarTaskService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CalendarTask>> GetAllAsync()
        {
            return await _context.CalendarTask.ToListAsync();
        }
        public async Task<List<CalendarTask>> GetByCalendarIdAsync(int[] calendarIds)
        {
            return await _context.CalendarTask.Where(x => calendarIds.Contains(x.CalendarId)).ToListAsync();
        }
        public async Task<int> AddItem(CalendarTask calendarTask)
        {
            _context.CalendarTask.Add(calendarTask);
            await _context.SaveChangesAsync();
            return calendarTask.Id;
        }

    }
}
