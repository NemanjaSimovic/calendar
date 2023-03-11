using Calendar_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar_api.Data
{
    public class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Calendar> Calendar => Set<Calendar>();
        public DbSet<CalendarTask> CalendarTask => Set<CalendarTask>();
        public DbSet<CalendarHoliday> CalendarHoliday => Set<CalendarHoliday>();
        public DbSet<CalendarColor> CalendarColor => Set<CalendarColor>();
        public DbSet<Emoji> Emoji => Set<Emoji>();
        public DbSet<User> User => Set<User>();
        public DbSet<UserCalendarTask> UserCalendarTask => Set<UserCalendarTask>();
        public DbSet<Role> Role => Set<Role>();
    }
}
