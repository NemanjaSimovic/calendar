using Calendar_api.Data;
using Calendar_api.Models;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarTaskController : ControllerBase
    {
        private readonly CalendarTaskService _calendarTaskService;
        private readonly CalendarService _calendarService;
        private readonly UserService _userService;
        private readonly UserCalendarTaskService _userCalendarTaskService;
        private readonly CalendarColorService _calendarColorService;
        private readonly EmojiService _emojiService;


        public CalendarTaskController(DataContext dataContext)
        {
            _calendarTaskService = new CalendarTaskService(dataContext);
            _calendarService = new CalendarService(dataContext);
            _userCalendarTaskService = new UserCalendarTaskService(dataContext);
            _calendarColorService = new CalendarColorService(dataContext);
            _userService = new UserService(dataContext);
            _emojiService = new EmojiService(dataContext);
        }
        [HttpGet]
        public async Task<ActionResult<List<CalendarTask>>> GetAllExtendedAsync()
        {
            List<CalendarTask> allCalendarTasks = await _calendarTaskService.GetAllAsync();
            List<CalendarTaskExtended> allCalendarTasksExtended = await convertCalendarTaskToExtendedAsync(allCalendarTasks);
            if(allCalendarTasks.Count >= 1 && allCalendarTasksExtended.Count < 1)
            {
                return NotFound(JsonSerializer.Serialize("Some of the ExtendedCalendarTask properties are missing in all the selected tasks!"));
            }
            return Ok(JsonSerializer.Serialize(allCalendarTasks));
        }
        [HttpGet]
        public async Task<ActionResult<List<CalendarTask>>> GetAllAsync()
        {
            List<CalendarTask> allCalendarTasks = await _calendarTaskService.GetAllAsync();
            return Ok(JsonSerializer.Serialize(allCalendarTasks));
        }
        [HttpPost]
        public async Task<ActionResult<bool>> AddItem(CalendarTaskExtended calendarTaskExtended)
        {
            if (!checkAllPaticipantsAvailable())
            {
                return BadRequest(JsonSerializer.Serialize("Some of the users is not available at that time!"));
            }

            CalendarTask calendarTask = new CalendarTask(
                calendarTaskExtended.Title,
                calendarTaskExtended.Description,
                calendarTaskExtended.StartTime,
                calendarTaskExtended.EndTime,
                calendarTaskExtended.CalendarId,
                calendarTaskExtended.CreatorId,
                calendarTaskExtended.CalendarColorId,
                calendarTaskExtended.EmojiId,
                calendarTaskExtended.KnownForEveryone,
                calendarTaskExtended.CaptionForEveryone,
                calendarTaskExtended.DescriptionForEveryone
            );
            int calendarTaskId = await _calendarTaskService.AddItem(calendarTask);
            await _userCalendarTaskService.AddAllParticipants(calendarTaskId, calendarTaskExtended.ParticipantIds);
            //todo - add signalr broadcast
            return Ok(JsonSerializer.Serialize("Calendar task successfully added!"));
        }

        private async Task<List<CalendarTaskExtended>> convertCalendarTaskToExtendedAsync(List<CalendarTask> tasks)
        {
            List<CalendarTaskExtended>? extendedTasks = new List<CalendarTaskExtended>();
            foreach (var task in tasks)
            {
                Calendar? calendar = await _calendarService.GetItemById(task.CalendarId);
                CalendarColor? calendarColor = await _calendarColorService.GetItemById(task.CalendarColorId);
                Emoji? emoji = await _emojiService.GetItemById(task.EmojiId);
                User? creator = await _userService.GetItemById(task.CreatorId);
                if (calendar == null ||calendarColor == null || emoji == null || creator == null)
                {
                    continue;
                }

                List<int> participantIds = new List<int>();
                List<string> participantNames = new List<string>();
                User? participant;
                
                List<UserCalendarTask> userCalendarTasks = await _userCalendarTaskService.GetAllByCalendarTaskIdAsync(task.Id);
                if(userCalendarTasks.Count < 1)
                {
                    continue;
                }
                foreach (var userCalendarTask in userCalendarTasks)
                {
                    participant = await _userService.GetItemById(userCalendarTask.userId);
                    if (participant == null)
                    {
                        continue;
                    }
                    participantIds.Add(participant.Id);
                    participantNames.Add(participant.Name);
                }

                CalendarTaskExtended extednedTask =
                new CalendarTaskExtended(
                    task.Id,
                    task.Title,
                    task.Description,
                    task.StartTime,
                    task.EndTime,
                    task.CalendarId,
                    calendar.Name,
                    participantIds,
                    participantNames,
                    task.CreatorId,
                    creator.Name,
                    task.CalendarColorId,
                    calendarColor.BackgroundColor,
                    task.EmojiId,
                    emoji.Emoticon,
                    task.KnownForEveryone,
                    task.CaptionForEveryone,
                    task.DescriptionForEveryone
                );
                extendedTasks.Add(extednedTask);
            }
            return extendedTasks;
        }

        private bool checkAllPaticipantsAvailable()
        {
            //todo
            return true;
        }
    }
}
