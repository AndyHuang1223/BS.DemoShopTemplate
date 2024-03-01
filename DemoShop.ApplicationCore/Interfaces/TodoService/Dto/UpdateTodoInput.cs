using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Interfaces.TodoService.Dto;

public class UpdateTodoInput
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Description { get; set; }
    [Required]
    public bool IsDone { get; set; }
}