using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/calendar/type")]
public class CalendarTypeController : ControllerBase
{

    private readonly CalendarTypeService _calendarTypeService;

    public CalendarTypeController(CalendarTypeService calendarTypeService)
    {
        _calendarTypeService = calendarTypeService;
    }

    [HttpGet("get/all")]
    public async Task<List<CalendarType>> GetAll() {
        return await _calendarTypeService.GetAsyncAll();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post(CalendarType calType) {
        await _calendarTypeService.createAsync(calType);
        // return NoContent();
        return CreatedAtAction(nameof(GetAll), new { id = calType.Id}, calType );
    }

    // [HttpPut("change/color")]
    // public async Task<IActionResult> AddToPlaylist(string urgency, string color) {
    //     await _urgencyColorService.UpdateColorAsync(urgency, color);
    //     return NoContent();
    // }

    // [HttpDelete("remove/{id}")]
    // public async Task<IActionResult> Delete(string id) {
    //     await _urgencyColorService.DeleteAsync(id);
    //     return NoContent();
    // }
}