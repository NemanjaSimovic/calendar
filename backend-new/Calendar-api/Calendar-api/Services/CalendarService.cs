using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class CalendarService
    {
        private readonly DataContext _context;
        public CalendarService(DataContext context)
        {
            _context = context;
        }

        public async Task AddItem(Calendar calendar)
        {
            _context.Calendar.Add(calendar);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Calendar>> GetAllAsync()
        {
            return await _context.Calendar.ToListAsync();
        }

        public async Task<List<Calendar>> GetAllForTaskAsync()
        {
            return await _context.Calendar.Where(c => !c.IsForHolidays && c.Name != Utilities.Utilities.PersonalHolidayCalendarName).ToListAsync();
        }

        public async Task<List<Calendar>> GetAllForHolidayAsync()
        {
            return await _context.Calendar.Where(c => c.IsForHolidays).ToListAsync();
        }

        public async Task<Calendar?> GetItemById(int id)
        {
            return await _context.Calendar.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
