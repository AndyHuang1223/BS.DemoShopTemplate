using BS.DemoShop.Web.Services.TodoService.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Services.TodoService
{
    public interface ITodoService
    {
        IEnumerable<TodoDTO> GetAll();
        TodoDTO GetById(int id);
        Task<TodoDTO> CreateTodo(CreateTodoDTO request);
        Task<TodoDTO> Update(TodoDTO request);
        Task Delete(TodoDTO request);
    }
}
