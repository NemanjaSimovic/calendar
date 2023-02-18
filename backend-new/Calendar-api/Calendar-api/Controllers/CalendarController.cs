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
    public class CalendarController : ControllerBase
    {
        private readonly CalendarService _calendarService;

        public CalendarController(DataContext dataContext)
        {
            _calendarService = new CalendarService(dataContext);
        }

        [HttpGet]        
        public async Task<ActionResult<List<Calendar>>> GetAllAsync()
        {
            return Ok(JsonSerializer.Serialize(await _calendarService.GetAllAsync()));
        }

        [HttpGet]
        [Route("fortask")]
        public async Task<ActionResult<List<Calendar>>> GetAllForTaskAsync()
        {
            return Ok(JsonSerializer.Serialize(await _calendarService.GetAllForTaskAsync()));
        }

        [HttpGet]
        [Route("forholiday")]
        public async Task<ActionResult<List<Calendar>>> GetAllForHolidayAsync()
        {
            return Ok(JsonSerializer.Serialize(await _calendarService.GetAllForHolidayAsync()));
        }

        [HttpPost]
        public async Task<ActionResult<List<Calendar>>> AddItem(Calendar calendar)
        {
            await _calendarService.AddItem(calendar);
            return Ok(JsonSerializer.Serialize(await _calendarService.GetAllAsync()));
        }
    }
}
