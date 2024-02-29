using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces.TodoService;

public interface ITodoService
{
    Task<TodoItem> CreateTodoAsync(string description);
    Task<TodoItem> GetTodoAsync(int id);
    Task<List<TodoItem>> GetTodosAsync();
    Task<TodoItem> UpdateTodoAsync(int id, string description, bool isDone);
    Task<TodoItem> DeleteTodoAsync(int id);
}