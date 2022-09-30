using System.ComponentModel.DataAnnotations;

namespace BS.DemoShop.Web.Services.TodoService.DTO
{
    public class TodoDTO
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public bool IsComplete { get; set; }
    }
}
