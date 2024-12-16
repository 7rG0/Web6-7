using Web6_7.Interfaces;
using Web6_7.Models;
using Web6_7.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreData _storeService;

    public StoreController(IStoreData StoreService)
    {
        _storeService = StoreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _storeService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Store model)
    {
        var result = await _storeService.AddAsync(model);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Store model)
    {
        var result = await _storeService.UpdateAsync(id, model);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _storeService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}