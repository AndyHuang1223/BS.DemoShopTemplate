using BS.DemoShop.Web.BaseModels;
using BS.DemoShop.Web.Enums;
using BS.DemoShop.Web.Filters;
using BS.DemoShop.Web.Services.TodoService;
using BS.DemoShop.Web.Services.TodoService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.WebApi
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ExceptionHandle]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;
        public TodoController(ITodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<BaseResult> GetAll()
        {
            var result = new BaseResult();
            var todoList = _todoService.GetAll().ToList();
            if (!todoList.Any())
            {
                result.IsSuccess = false;
                result.Response = ApiStatus.NotFound;
                return result;
            }
            result.Body = todoList;

            return result;
        }

        [HttpGet]
        public ActionResult<BaseResult> Get(int id)
        {
            var result = new BaseResult();
            var todoList = _todoService.GetById(id);
            if (todoList == null)
            {
                _logger.LogInformation("Todo {TodoId} is not found", id);
                result.IsSuccess = false;
                result.Response = ApiStatus.NotFound;
                return result;
            }
            result.Body = todoList;
            return result;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDTO request)
        {
            var result = await _todoService.CreateTodo(request);
            //return CreatedAtAction("Get", new { Id = result.Id });
            return Ok(new BaseResult() { Body = result });
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TodoDTO request)
        {
            var result = new BaseResult();

            var todo = await _todoService.Update(request);
            if (todo == null)
            {
                _logger.LogInformation("Todo {TodoId} is not found", request.Id);
                result.IsSuccess = false;
                result.Response = ApiStatus.NotFound;
                return Ok(result);
            }
            result.Body = todo;
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTodoDTO request)
        {
            var result = new BaseResult();
            var source = _todoService.GetById(request.Id);
            if (source == null)
            {
                _logger.LogInformation("Todo {TodoId} is not found", request.Id);
                result.IsSuccess = false;
                result.Response = ApiStatus.NotFound;
                return Ok(result);
            }
            await _todoService.Delete(source);
            return Ok(result);

        }
    }
}
