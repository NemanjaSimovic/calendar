using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/emoji")]
public class NameEmojiController : ControllerBase
{

    private readonly NameEmojiService _nameEmojiService;

    public NameEmojiController(NameEmojiService nameEmojiService)
    {
        _nameEmojiService = nameEmojiService;
    }

    [HttpGet("get/all")]
    public async Task<List<NameEmoji>> GetAll() {
        return await _nameEmojiService.GetAsyncAll();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post(NameEmoji nameEmoji) {
        await _nameEmojiService.createAsync(nameEmoji);
        // return NoContent();
        return CreatedAtAction(nameof(GetAll), new { id = nameEmoji.Id}, nameEmoji );
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