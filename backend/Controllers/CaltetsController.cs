using System;
using Microsoft.AspNetCore.Mvc;
using CalApp.Models;
using CalApp.Services;

namespace CalApp.Controllers;

[ApiController]
[Route("/test")]
public class CalTestsController : ControllerBase
{

    private readonly MongoDBService _mongoDBService;

    public CalTestsController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet("get/all")]
    public async Task<List<Caltest>> Get() {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost("add")]
    public async Task<IActionResult> Post([FromBody] Caltest test) {
        await _mongoDBService.createAsync(test);
        return CreatedAtAction(nameof(Get), new { id = test.Id}, test );
    }

    [HttpPut("changetitle/{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string newTitle) {
        await _mongoDBService.UpdateTitleAsync(id, newTitle);
        return NoContent();
    }

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _mongoDBService.DeleteAsync(id);
        return NoContent();
    }
    // [HttpGet("get/all")]
    // public async Task<ActionResult<List<TDtask>>> GetAll() =>
    //     TDTaskService.GetAll();

    // [HttpGet("get/{id}")]
    // public ActionResult<TDtask> Get(int id, string[] color)
    // {
    //     var task = TDTaskService.Get(id);

    //     if(task == null)
    //         return NotFound();
        
    //     return task;
    // }

    // [HttpGet("get/bycolor")]
    // public async Task<ActionResult<List<TDtask>>> GetByColor(string color)
    // {
    //     var tasks = TDTaskService.GetByColor(color);

    //     if(tasks == null)
    //         return NotFound();
        
    //     return tasks;
    // }

    // [HttpPost("add")]
    // public IActionResult Create(TDtask task)
    // {
    //     TDTaskService.Add(task);
    //     return CreatedAtAction(nameof(Create), new {id = task.Id}, task);
    // }

    // [HttpPut("{id}")]
    // public IActionResult Update(int id, TDtask task)
    // {
    //     if (id != task.Id)
    //         return BadRequest();
            
    //     var existingTask = TDTaskService.Get(id);
    //     if(existingTask is null)
    //         return NotFound();
    
    //     TDTaskService.Update(task);           
    
    //     return NoContent();
    // }

    // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     var task = TDTaskService.Get(id);
    
    //     if (task is null)
    //         return NotFound();
        
    //     TDTaskService.Delete(id);
    
    //     return NoContent();
    // }
}