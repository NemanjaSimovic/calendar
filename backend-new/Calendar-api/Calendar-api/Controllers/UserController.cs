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
        private readonly UserCalendarTaskService _userCalendarTaskService;

        public UserController(DataContext dataContext)
        {
            _userService = new UserService(dataContext);
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

        public async Task<List<UserAvailabillityDto>> GetUsersAvailabilityForTimeRange(DateTime startTime, DateTime endTime)
        {
            List<User> allUsers = await _userService.GetAllAsync();
            List<UserAvailabillityDto> usersAvailability = new List<UserAvailabillityDto>();
            foreach(User user in allUsers)
            {
                UserAvailabillityDto userAvailability = new UserAvailabillityDto(user.Id, user.Name, false);
                List<CalendarTask> allCalendarTasksForUser = await _userCalendarTaskService.GetCalendarTasksbyUserId(user.Id);
                usersAvailability.Add(userAvailability);
            }

            return usersAvailability;
        }
    }
}
