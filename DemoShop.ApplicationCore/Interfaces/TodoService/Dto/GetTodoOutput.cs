namespace DemoShop.ApplicationCore.Interfaces.TodoService.Dto;

public class GetTodoOutput
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}