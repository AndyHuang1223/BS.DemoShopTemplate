using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Interfaces.TodoService.Dto;

public class CreateTodoInput
{
    [Required]
    [MaxLength(30)]
    public string Description { get; set; }
}