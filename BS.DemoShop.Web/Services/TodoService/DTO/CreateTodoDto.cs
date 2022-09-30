using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.Services.TodoService.DTO
{
    public class CreateTodoDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
