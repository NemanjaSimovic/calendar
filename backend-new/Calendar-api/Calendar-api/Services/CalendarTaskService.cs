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

        public async Task<List<CalendarTask>> GetAllByMonthAsync(DateTime minStartTime)
        {
            DateTime maxStartTime = minStartTime.AddMonths(1);
            return await _context.CalendarTask.Where(t => t.StartTime >= minStartTime && t.StartTime <= maxStartTime).OrderBy(t => t.StartTime).ToListAsync();
        }

        public async Task<List<CalendarTask>> GetAllForUserByMonthAsync(DateTime minStartTime, int userId)
        {
            DateTime maxStartTime = minStartTime.AddMonths(1);
            List<UserCalendarTask> CalendarTasksByUser = await _context.UserCalendarTask.Where(u => u.UserId == userId).ToListAsync();
            List<int> taskIdsByUser = CalendarTasksByUser.Select(u => u.CalendarTaskId).ToList();
            return await _context.CalendarTask.Where(t => taskIdsByUser.Contains(t.Id) && t.StartTime >= minStartTime && t.StartTime <= maxStartTime).OrderBy(t => t.StartTime).ToListAsync();
        }
        public async Task<List<int>> GetCalendarTaskIdsConflictedWithEnteredTime(DateTime startTime, DateTime endTime, int calendarId)
        {
            if(calendarId != Utilities.Utilities.WorkCalendarId)
            {
                return await _context.CalendarTask
                .Where(t => (!t.IsNotWorkingHoliday && ((startTime <= t.StartTime && endTime > t.StartTime) || (startTime >= t.StartTime && startTime < t.EndTime))))
                .Select(t => t.Id)
                .ToListAsync();
            }
            else
            {
                return await _context.CalendarTask
                .Where(t => (((startTime <= t.StartTime && endTime > t.StartTime) || (startTime >= t.StartTime && startTime < t.EndTime)))
                )
                .Select(t => t.Id)
                .ToListAsync();
            }
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
