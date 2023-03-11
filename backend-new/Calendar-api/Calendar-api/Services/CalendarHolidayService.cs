using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;


namespace Calendar_api.Services
{
    public class CalendarHolidayService
    {
        private readonly DataContext _context;
        public CalendarHolidayService(DataContext context)
        {
            _context = context;
        }

        public async Task AddItem(CalendarHoliday calendarHoliday)
        {
            _context.CalendarHoliday.Add(calendarHoliday);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CalendarHoliday>> GetAllAsync()
        {
            return await _context.CalendarHoliday.ToListAsync();
        }

        public async Task<List<CalendarHoliday>> GetByMonthAsync(int month)
        {
            return await _context.CalendarHoliday.Where(h => h.Month == month).ToListAsync();
        }

        public async Task<Calendar?> GetItemById(int id)
        {
            return await _context.Calendar.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
