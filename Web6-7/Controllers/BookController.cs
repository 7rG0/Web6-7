using Web6_7.Interfaces;
using Web6_7.Models;
using Web6_7.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookData _bookService;

    public BookController(IBookData BookService)
    {
        _bookService = BookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _bookService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Book model)
    {
        var result = await _bookService.AddAsync(model);
        return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Book model)
    {
        var result = await _bookService.UpdateAsync(id, model);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _bookService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}