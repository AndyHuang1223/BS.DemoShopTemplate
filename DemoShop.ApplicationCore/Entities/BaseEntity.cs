using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public int Seq { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}