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
    }
}
