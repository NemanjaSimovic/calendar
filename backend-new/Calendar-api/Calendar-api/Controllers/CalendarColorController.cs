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
    public class CalendarColorController : ControllerBase
    {
        private readonly CalendarColorService _calendarColorService;

        public CalendarColorController(DataContext dataContext)
        {
            _calendarColorService = new CalendarColorService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            List<CalendarColor> allCalendarColors = await _calendarColorService.GetAllAsync();
            return Ok(JsonSerializer.Serialize(allCalendarColors));
        }


    }
}
