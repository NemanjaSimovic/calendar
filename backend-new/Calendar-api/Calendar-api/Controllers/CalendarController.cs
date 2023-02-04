using Calendar_api.Data;
using Calendar_api.Models;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _calendarService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Calendar>>> AddItem(Calendar calendar)
        {
            await _calendarService.AddItem(calendar);
            return Ok(await _calendarService.GetAllAsync());
        }
    }
}
