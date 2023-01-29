using Calendar_api.Data;
using Calendar_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calendar_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarColorController : ControllerBase
    {
        private readonly CalendarColorService _calendarColorService;

        public CalendarColorController(DataContext dataContext)
        {
            _calendarColorService = CalendarColorService.GetInstance(dataContext);
        }
    }
}
