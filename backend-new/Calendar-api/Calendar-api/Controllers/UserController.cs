using Calendar_api.Data;
using Calendar_api.Models;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CalendarTaskService _calendarTaskService;
        private readonly UserCalendarTaskService _userCalendarTaskService;

        public UserController(DataContext dataContext)
        {
            _userService = new UserService(dataContext);
            _calendarTaskService = new CalendarTaskService(dataContext);
            _userCalendarTaskService = new UserCalendarTaskService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllAsync()
        {
            List<User> allUsers = await _userService.GetAllAsync();
            return Ok(JsonSerializer.Serialize(allUsers, Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<bool>> Login([FromBody] User body)
        {
            if (body.Username == null || body.Password == null)
            {
                return Unauthorized("Username or password empty!");
            }
            bool usrExists = await _userService.UsernameExists(body.Username);
            if (usrExists == false)
            {
                return Unauthorized("No username in database found!");
            }
            var user = await _userService.GetByUsernameAndPass(body.Username, body.Password);
            if (user == null)
            {
                return Unauthorized(JsonSerializer.Serialize("Wrong password!"));
            }
            return Ok(JsonSerializer.Serialize(user, Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register([FromBody] User body)
        {
            if (body.Username == null)
            {
                return Unauthorized(JsonSerializer.Serialize("Username or password empty!"));
            }
            bool usrExists = await _userService.UsernameExists(body.Username);
            if (usrExists)
            {
                return Unauthorized(JsonSerializer.Serialize("Username already taken!"));
            }
            await _userService.AddItem(body);
            return Ok(JsonSerializer.Serialize("User successfully registered!"));
        }

        [HttpGet]
        [Route("availability")]
        public async Task<List<UserAvailabilityDto>> GetUsersAvailabilityForTimeRange(DateTime startTime, DateTime endTime)
        {
            List<int> conflictedTaskIds = await _calendarTaskService.GetCalendarTaskIdsConflictedWithEnteredTime(startTime, endTime);
            List<int> unavailableUserIds = new List<int>();
            List<int> unavailableUserIdsForCalendarTask;

            foreach(int taskId in conflictedTaskIds)
            {
                unavailableUserIdsForCalendarTask = await _userCalendarTaskService.GetUserIdsByCalendarTaskId(taskId);
                unavailableUserIds.AddRange(unavailableUserIdsForCalendarTask);
            }

            unavailableUserIds = unavailableUserIds.Distinct().ToList();
            List<UserAvailabilityDto> usersAvailability = new List<UserAvailabilityDto>();
            List<User> allUsers = await _userService.GetAllAsync();

            foreach(User user in allUsers)
            {
                bool availability = true;
                if (unavailableUserIds.Contains(user.Id))
                {
                    availability = false;
                }

                UserAvailabilityDto userDto = new UserAvailabilityDto(user.Id, user.Name, availability);
                usersAvailability.Add(userDto);
            }

            return usersAvailability;
        }
    }
}
