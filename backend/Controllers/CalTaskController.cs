using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/task")]
public class CaltaskController : ControllerBase
{
    public static DateTime ToDateTime(long timestamp)
    {
        var dateTime = new DateTime(1970,1,1,0,0,0,0, DateTimeKind.Utc);
        return dateTime.AddSeconds(timestamp / 1000).ToLocalTime();
    }

    private readonly CalTaskService _taskService;

    public CaltaskController(CalTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("get/all")]
    public async Task<List<Caltask>> GetAll() {
        return await _taskService.GetAsyncAll();
    }

    [HttpGet("get/bymonth")]
    public async Task<List<Caltask>?> GetByMonth(string month) {
        return await _taskService.GetAsyncAllByMonth(month);
    }
    [HttpGet("get/byidandmonth")]
    public async Task<List<Caltask>?> GetByIdAndMonth(string month, string id) {
        return await _taskService.GetAsyncByIdAndMonth(month, id);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post([FromBody] Caltask body, long startEpoch, long endEpoch) {
         Caltask task = new Caltask();
        if(body.title != null)
            task.title = body.title;

        if(body.description != null)
            task.description = body.description;

        if(body.color != null)
            task.color = body.color;
        
        if(body.participantIds != null)
            task.participantIds = body.participantIds;
        
        if(body.participantFullNames != null)
            task.participantFullNames = body.participantFullNames;

        if(body.creatorId != null)
            task.creatorId = body.creatorId;

        if(body.creatorFullName != null)
            task.creatorFullName = body.creatorFullName;
        
        task.startTime = CaltaskController.ToDateTime(startEpoch);
        task.endTime = CaltaskController.ToDateTime(endEpoch);

        await _taskService.createAsync(task);
        return NoContent();
        // return CreatedAtAction(nameof(GetAll), new { id = user.Id}, user );
    }

    // [HttpPut("changepasswrod/{id}")]
    // public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string newPassword) {
    //     await _userService.UpdatePasswordAsync(id, newPassword);
    //     return NoContent();
    // }

    // [HttpDelete("remove/{id}")]
    // public async Task<IActionResult> Delete(string id) {
    //     await _userService.DeleteAsync(id);
    //     return NoContent();
    // }
}