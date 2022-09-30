using BS.DemoShop.Web.BaseModels;
using BS.DemoShop.Web.Enums;
using BS.DemoShop.Web.Filters;
using BS.DemoShop.Web.Services.TodoService;
using BS.DemoShop.Web.Services.TodoService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// 取得所有Todo(出現在API url 後面)
        /// </summary>
        /// <returns>所有Todo</returns>
        /// <remarks>取得所有Todo Description(出現在下拉區塊)</remarks>
        /// <response code="200">取得成功(出現在下拉後Response區塊)</response>
        // / <response code="404">查無資料</response>
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

        /// <summary>
        /// 根據Todo Id 取得 Todo
        /// </summary>
        /// <param name="id">todo id(出現在下拉後 Parameters 對應的欄位)</param>
        /// <returns>Todo Info</returns>
        /// <remarks>取得特定Todo</remarks>
        [HttpGet]
        public ActionResult<BaseResult> Get([Required]int id) // 設為 Required 後, Parameters 上對應的欄位會設為必填
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

        /// <summary>
        /// 新增 Todo
        /// </summary>
        /// <param name="request">Todo Request</param>
        /// <returns></returns>
        /// <remarks>
        /// sample request:
        /// 
        ///     POST/Create:
        ///     {
        ///         Name: "要串swagger"        
        ///     }
        /// </remarks>
        [Produces("application/json")] // 聲明Response類型
        [Consumes("application/json")] // 聲明Content-Type類型
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDTO request)
        {
            var result = await _todoService.CreateTodo(request);
            //return CreatedAtAction("Get", new { Id = result.Id });
            return Ok(new BaseResult() { Body = result });
        }

        /// <summary>
        /// 編輯 Todo
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// sample request:
        /// 
        ///     PUT/Update:
        ///     {
        ///         "Id": 1,
        ///         "Name": "要寫swagger doc",
        ///         "IsComplete": true
        ///     }
        /// </remarks>
        [Produces("application/json")]
        [Consumes("application/json")]
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
