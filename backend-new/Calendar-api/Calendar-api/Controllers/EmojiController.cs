using Calendar_api.Data;
using Calendar_api.Models;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmojiController : ControllerBase
    {
        private readonly EmojiService _emojiService;

        public EmojiController(DataContext dataContext)
        {
            _emojiService = new EmojiService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<Emoji>>> GetAllAsync()
        {
            return Ok(JsonSerializer.Serialize(await _emojiService.GetAllAsync()));
        }
        [HttpPost]
        public async Task<ActionResult<List<Emoji>>> AddItem(Emoji emoji)
        {
            await _emojiService.AddItem(emoji);
            return Ok(JsonSerializer.Serialize(await _emojiService.GetAllAsync()));
        }
    }
}
