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
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(DataContext dataContext)
        {
            _roleService = new RoleService(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            return Ok(JsonSerializer.Serialize(await _roleService.GetAllAsync(), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }
        [HttpPost]
        public async Task<ActionResult<List<Role>>> AddItem(Role role)
        {
            await _roleService.AddItem(role);
            return Ok(JsonSerializer.Serialize(await _roleService.GetAllAsync(), Utilities.Utilities.JsonCaseLowerCaseSerializeOption));
        }
    }
}
