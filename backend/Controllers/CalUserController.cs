using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/user")]
public class CaluserController : ControllerBase
{

    private readonly CalUserService _userService;

    public CaluserController(CalUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("get/all")]
    public async Task<List<Caluser>> GetAll() {
        return await _userService.GetAsyncAll();
    }

    [HttpGet("get/byuserandpass")]
    public async Task<Caluser?> GetById(string username, string password) {
        return await _userService.GetAsyncByUserAndPass(username, password);
    }

    [HttpPost("post/register")]
    public async Task<IActionResult> Post([FromBody] Caluser body) {
        Caluser user = new Caluser();
        if(body.username != null)
            user.username = body.username;

        if(body.password != null)
            user.password = body.password;

        if(body.name != null)
            user.name = body.name;
        
        if(body.surname != null)
            user.surname = body.surname;
        
        if(body.email != null)
            user.email = body.email;
        
        await _userService.createAsync(user);
        return CreatedAtAction(nameof(GetAll), new { id = user.Id}, user );
    }

    [HttpPut("changepasswrod/{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string newPassword) {
        await _userService.UpdatePasswordAsync(id, newPassword);
        return NoContent();
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}