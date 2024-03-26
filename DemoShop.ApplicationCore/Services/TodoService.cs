using DemoShop.ApplicationCore.Entities;
using DemoShop.ApplicationCore.Interfaces;
using DemoShop.ApplicationCore.Interfaces.TodoService;

namespace DemoShop.ApplicationCore.Services;

public class TodoService : ITodoService
{
    private readonly IRepository<TodoItem> _todoRepository;

    public TodoService(IRepository<TodoItem> todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoItem> CreateTodoAsync(string description)
    {
        var todo = new TodoItem
        {
            Description = description,
            IsDone = false,
            CreateAt = DateTime.Now,
        };
        return await _todoRepository.AddAsync(todo);
    }

    public async Task<TodoItem> GetTodoAsync(int id)
    {
        var targetTodo = await _todoRepository.GetByIdAsync(id);
        if (targetTodo is null || targetTodo.IsDelete)
        {
            return null;
        }
        return await _todoRepository.GetByIdAsync(id);
    }

    public async Task<List<TodoItem>> GetTodosAsync()
    {
        return await _todoRepository.ListAsync(x => x.IsDelete == false);
    }

    public async Task<TodoItem> UpdateTodoAsync(int id, string description, bool isDone)
    {
        var targetTodo = await _todoRepository.GetByIdAsync(id);
        if (targetTodo is null || targetTodo.IsDelete)
        {
            return null;
        }

        targetTodo.Description = description;
        targetTodo.IsDone = isDone;
        targetTodo.UpdateAt = DateTime.Now;
        return await _todoRepository.UpdateAsync(targetTodo);
    }

    public async Task<TodoItem> DeleteTodoAsync(int id)
    {
        var targetTodo = await _todoRepository.GetByIdAsync(id);
        if (targetTodo is null || targetTodo.IsDelete)
        {
            return null;
        }

        targetTodo.IsDelete = true;
        return await _todoRepository.UpdateAsync(targetTodo);
    }
}