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
    public class CalendarHolidayController : ControllerBase
    {
        private readonly CalendarHolidayService _calendarHolidayService;

        public CalendarHolidayController(DataContext dataContext)
        {
            _calendarHolidayService = new CalendarHolidayService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<CalendarHoliday>>> GetAllAsync()
        {
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetAllAsync(), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpGet]
        [Route("bymonth")]
        public async Task<ActionResult<List<CalendarHoliday>>> GetByMonthAsync(int month)
        {
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetByMonthAsync(month), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpPost]
        public async Task<ActionResult<List<Calendar>>> AddItem(CalendarHoliday calendarHoliday)
        {
            await _calendarHolidayService.AddItem(calendarHoliday);
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetAllAsync()));
        }
    }
}
