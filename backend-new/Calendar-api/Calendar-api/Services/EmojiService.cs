using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class EmojiService
    {
        private readonly DataContext _context;
        public EmojiService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Emoji>> GetAllAsync()
        {
            return await _context.Emoji.ToListAsync();
        }
        public async Task AddItem(Emoji emoji)
        {
            _context.Emoji.Add(emoji);
            await _context.SaveChangesAsync();
        }
    }
}
