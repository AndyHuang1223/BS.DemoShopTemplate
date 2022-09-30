using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Web.Services.TodoService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepo;

        public TodoService(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public async Task<TodoDTO> CreateTodo(CreateTodoDTO request)
        {
            var todo = new Todo()
            {
                Name = request.Name,
                CreateTime = System.DateTimeOffset.UtcNow
            };
            var entity = await _todoRepo.AddAsync(todo);
            
            var result = new TodoDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                IsComplete = entity.IsComplete
            };
            
            return result;
        }

        public async Task Delete(TodoDTO request)
        {
            var source = _todoRepo.FirstOrDefault(x => x.Id == request.Id);
            if(source == null)
            {
                //TODO 未找到處理
               return;
            }
            
            await _todoRepo.DeleteAsync(source);
            
        }

        public IEnumerable<TodoDTO> GetAll()
        {
            var result = _todoRepo.GetAll().Select(t => new TodoDTO
            {
                Id = t.Id,
                Name = t.Name,
                IsComplete = t.IsComplete
            });
            return result;
        }

        public TodoDTO GetById(int id)
        {
            var todo = _todoRepo.GetById(id);
            
            if(todo == null)
            {
                //TODO 未找到處理
                return default;
            }

            var result = new TodoDTO()
            {
                Id = todo.Id,
                Name = todo.Name,
                IsComplete = todo.IsComplete
            };

            return result;
        }

        public async Task<TodoDTO> Update(TodoDTO request)
        {
            var source = await _todoRepo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(source == null)
            {
                //TODO 未找到處理
                return default;
            }
            source.Name = request.Name;
            source.IsComplete = request.IsComplete;
            source.UpdateTime = DateTimeOffset.UtcNow;
            var entity = _todoRepo.Update(source);
            var result = new TodoDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                IsComplete = entity.IsComplete
            };

            return result;
        }
    }
}
