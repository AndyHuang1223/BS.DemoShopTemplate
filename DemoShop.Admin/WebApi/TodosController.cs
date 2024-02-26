using DemoShop.ApplicationCore.Interfaces.TodoService;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Admin.WebApi;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var todos = await _todoService.GetTodosAsync();
        if (todos.Count > 0)
        {
            return Ok(todos);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var todo = await _todoService.GetTodoAsync(id);
        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoAsync(string description)
    {
        var todo = await _todoService.CreateTodoAsync(description);
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoAsync(int id, string description)
    {
        var todo = await _todoService.UpdateTodoAsync(id, description);
        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoAsync(int id)
    {
        var todo = await _todoService.DeleteTodoAsync(id);
        if (todo is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}