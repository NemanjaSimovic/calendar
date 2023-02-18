using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class CalendarColorService
    {
        private readonly DataContext _context;
        public CalendarColorService(DataContext context)
        {
            _context = context;
        }

        public async Task<CalendarColor?> GetItemById(int id)
        {
            return await _context.CalendarColor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CalendarColor>> GetAllAsync()
        {
            return await _context.CalendarColor.ToListAsync();
        }

    }
}
