using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public bool IsDelete { get; set; }
    public DateTimeOffset CreateAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}