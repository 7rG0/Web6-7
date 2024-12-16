using Web6_7.Interfaces;
using Web6_7.Models;
using Web6_7.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorData _authorService;

    public AuthorController(IAuthorData AuthorService)
    {
        _authorService = AuthorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _authorService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Author model)
    {
        var result = await _authorService.AddAsync(model);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Author model)
    {
        var result = await _authorService.UpdateAsync(id, model);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _authorService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}