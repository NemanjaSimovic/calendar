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
        public async Task<List<UserCalendarTask>> GetAllByUserIdAsync(int userId)
        {
            return await _context.UserCalendarTask.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<List<CalendarTask>> GetCalendarTasksbyUserId(int userId)
        {
            List<int> calendarTaskIds = await _context.UserCalendarTask.Where(u => u.UserId == userId).Select(u => u.CalendarTaskId).ToListAsync();
            return await _context.CalendarTask.Where(c => calendarTaskIds.Contains(c.Id)).ToListAsync();
        }

        public async Task<List<User>> GetUsersByCalendarTaskId(int calendarTaskId)
        {
            List<int> userIds = await _context.UserCalendarTask.Where(u => u.CalendarTaskId == calendarTaskId).Select(u => u.UserId).ToListAsync();
            return await _context.User.Where(u => userIds.Contains(u.Id)).ToListAsync();
        }
        public async Task<List<int>> GetUserIdsByCalendarTaskId(int calendarTaskId)
        {
            List<int> userIds = await _context.UserCalendarTask.Where(u => u.CalendarTaskId == calendarTaskId).Select(u => u.UserId).ToListAsync();
            return await _context.User.Where(u => userIds.Contains(u.Id)).Select(u => u.Id).ToListAsync();
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
