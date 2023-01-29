using Calendar_api.Data;

namespace Calendar_api.Services
{
    public class CalendarColorService
    {
        private readonly DataContext _context;
        private static CalendarColorService _instance;
        private CalendarColorService(DataContext context)
        {
            _context = context;
        }
        public static CalendarColorService GetInstance(DataContext context)
        {
            if (_instance == null)
            {
                _instance = new CalendarColorService(context);
            }
            return _instance;
        }

    }
}
