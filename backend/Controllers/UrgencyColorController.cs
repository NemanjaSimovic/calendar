using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/urgency/color")]
public class UrgencyColorController : ControllerBase
{

    private readonly UrgencyColorService _urgencyColorService;

    public UrgencyColorController(UrgencyColorService urgencyColorService)
    {
        _urgencyColorService = urgencyColorService;
    }

    [HttpGet("get/all")]
    public async Task<List<UrgencyColor>> GetAll() {
        return await _urgencyColorService.GetAsyncAll();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post(UrgencyColor color) {
        await _urgencyColorService.createAsync(color);
        // return NoContent();
        return CreatedAtAction(nameof(GetAll), new { id = color.Id}, color );
    }

    [HttpPut("change/color")]
    public async Task<IActionResult> AddToPlaylist(string urgency, string color) {
        await _urgencyColorService.UpdateColorAsync(urgency, color);
        return NoContent();
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _urgencyColorService.DeleteAsync(id);
        return NoContent();
    }
}