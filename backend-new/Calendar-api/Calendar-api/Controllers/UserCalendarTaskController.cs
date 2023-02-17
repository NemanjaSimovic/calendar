using Calendar_api.Data;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCalendarTaskController : ControllerBase
    {
        private readonly UserCalendarTaskService _userCalendarTaskService;

        public UserCalendarTaskController(DataContext dataContext)
        {
            _userCalendarTaskService = new UserCalendarTaskService(dataContext);
        }
    }
}
