using Calendar_api.Data;
using Calendar_api.Models;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(DataContext dataContext)
        {
            _userService = new UserService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
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
                return Unauthorized("Wrong password!");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register([FromBody] User body)
        {
            if (body.Username == null)
            {
                return Unauthorized("Username or password empty!");
            }
            bool usrExists = await _userService.UsernameExists(body.Username);
            if (usrExists)
            {
                return Unauthorized("Username already taken!");
            }
            await _userService.AddItem(body);
            return Ok("User successfully registered!");
        }
    }
}
