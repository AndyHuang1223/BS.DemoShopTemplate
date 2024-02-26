using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class TodoItem : BaseEntity
{
    [Required]
    public string Description { get; set; }

    public bool IsDone { get; set; }
}