using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class RoleService
    {
        private readonly DataContext _context;
        public RoleService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task AddItem(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
        }
    }
}
