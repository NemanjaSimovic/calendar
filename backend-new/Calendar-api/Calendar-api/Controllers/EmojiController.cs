using Calendar_api.Data;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmojiController : ControllerBase
    {
        private readonly EmojiService _emojiService;

        public EmojiController(DataContext dataContext)
        {
            _emojiService = EmojiService.GetInstance(dataContext);
        }
    }
}
