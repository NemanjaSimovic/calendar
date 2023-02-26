using Calendar_api.Data;
using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Services
{
    public class UserCalendarTaskService
    {
        private readonly DataContext _context;
        public UserCalendarTaskService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserCalendarTask>> GetAllByCalendarTaskIdAsync(int calendarTaskId)
        {
            return await _context.UserCalendarTask.Where(u => u.CalendarTaskId == calendarTaskId).ToListAsync();
        }

        public async Task AddAllParticipants(int calendarTaskId, List<int> participantIds)
        {
            UserCalendarTask userCalendarTask;
            foreach(var participantId in participantIds)
            {
                userCalendarTask = new UserCalendarTask(calendarTaskId, participantId);
                await AddItem(userCalendarTask);
            }
        }

        public async Task AddItem(UserCalendarTask userCalendarTask)
        {
            _context.UserCalendarTask.Add(userCalendarTask);
            await _context.SaveChangesAsync();
        }

    }
}
