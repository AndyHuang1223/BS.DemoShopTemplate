using DemoShop.ApplicationCore.Interfaces.TodoService;
using DemoShop.ApplicationCore.Interfaces.TodoService.Dto;
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

        if (todos.Count <= 0)
        {
            return NotFound();
        }

        var result = todos.Select(todo => new GetTodoOutput
        {
            Id = todo.Id,
            Description = todo.Description,
            IsDone = todo.IsDone,
            CreatedAt = todo.CreateAt,
            UpdatedAt = todo.UpdateAt
        });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        var todo = await _todoService.GetTodoAsync(id);
        if (todo is null)
        {
            return NotFound(id);
        }

        var result = new GetTodoOutput
        {
            Id = todo.Id,
            Description = todo.Description,
            IsDone = todo.IsDone,
            CreatedAt = todo.CreateAt,
            UpdatedAt = todo.UpdateAt
        };
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoAsync([FromBody] CreateTodoInput input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var todo = await _todoService.CreateTodoAsync(input.Description);
        var result = new GetTodoOutput
        {
            Id = todo.Id,
            Description = todo.Description,
            IsDone = todo.IsDone,
            CreatedAt = todo.CreateAt,
            UpdatedAt = todo.UpdateAt
        };
        return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoAsync([FromBody] UpdateTodoInput input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var todo = await _todoService.UpdateTodoAsync(input.Id, input.Description, input.IsDone);
        if (todo is null)
        {
            return NotFound();
        }

        var result = new GetTodoOutput
        {
            Id = todo.Id,
            Description = todo.Description,
            IsDone = todo.IsDone,
            CreatedAt = todo.CreateAt,
            UpdatedAt = todo.UpdateAt
        };

        return Ok(result);
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