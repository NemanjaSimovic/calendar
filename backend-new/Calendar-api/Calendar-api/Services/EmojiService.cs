using Calendar_api.Data;

namespace Calendar_api.Services
{
    public class EmojiService
    {
        private readonly DataContext _context;
        private static EmojiService _instance;
        private EmojiService(DataContext context)
        {
            _context = context;
        }
        public static EmojiService GetInstance(DataContext context)
        {
            if (_instance == null)
            {
                _instance = new EmojiService(context);
            }
            return _instance;
        }
    }
}
