using Calendar_api.Data;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarTaskController : ControllerBase
    {
        private readonly CalendarTaskService _calendarTaskService;

        public CalendarTaskController(DataContext dataContext)
        {
            _calendarTaskService = CalendarTaskService.GetInstance(dataContext);
        }
    }
}
