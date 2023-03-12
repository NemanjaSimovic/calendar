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
        private readonly CalendarService _calendarService;
        private readonly CalendarColorService _calendarColorService;
        private readonly EmojiService _emojiService;


        public CalendarHolidayController(DataContext dataContext)
        {
            _calendarHolidayService = new CalendarHolidayService(dataContext);
            _emojiService = new EmojiService(dataContext);
            _calendarColorService = new CalendarColorService(dataContext);
            _calendarService = new CalendarService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<CalendarHoliday>>> GetAllAsync()
        {
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetAllAsync(), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpGet]
        [Route("bymonth")]
        public async Task<ActionResult<List<CalendarHoliday>>> GetByMonthAsync(int month, int year)
        {
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetByMonthAsync(month, year), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpGet]
        [Route("dto/bymonth")]
        public async Task<ActionResult<List<CalendarHoliday>>> GetByMonthDtosAsync(int month, int year)
        {
            List<CalendarHoliday> allHolidays = await _calendarHolidayService.GetByMonthAsync(month, year);
            List<CalendarHolidayDto> allHolidayDtos = await ConvertCalendarHolidayToDtoAsync(allHolidays);
            return Ok(JsonSerializer.Serialize(allHolidayDtos, Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpPost]
        public async Task<ActionResult<List<Calendar>>> AddItem(CalendarHoliday calendarHoliday)
        {
            await _calendarHolidayService.AddItem(calendarHoliday);
            return Ok(JsonSerializer.Serialize(await _calendarHolidayService.GetAllAsync()));
        }

        private async Task<List<CalendarHolidayDto>> ConvertCalendarHolidayToDtoAsync(List<CalendarHoliday> holidays)
        {
            List<CalendarHolidayDto>? holidayDtos = new List<CalendarHolidayDto>();
            foreach (var holiday in holidays)
            {
                Calendar? calendar = await _calendarService.GetItemById(holiday.CalendarId);
                CalendarColor? calendarColor = await _calendarColorService.GetItemById(holiday.CalendarColorId);
                Emoji? emoji = await _emojiService.GetItemById(holiday.EmojiId);
                if (calendar == null || calendarColor == null || emoji == null)
                {
                    continue;
                }

                CalendarHolidayDto holidayDto =
                new CalendarHolidayDto(
                    holiday.Id, holiday.Title, holiday.Description, holiday.CalendarId,
                    holiday.CalendarColorId, calendarColor.BackgroundColor,
                    holiday.EmojiId, emoji.Emoticon, holiday.IsRepeatedYearly,
                    holiday.Day, holiday.Month, holiday.Year, calendarColor.FontColor
                );
                holidayDtos.Add(holidayDto);
            }
            return holidayDtos;
        }
    }
}
