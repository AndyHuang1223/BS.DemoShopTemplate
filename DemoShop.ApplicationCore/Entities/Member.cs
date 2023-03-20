using System.ComponentModel.DataAnnotations;

namespace DemoShop.ApplicationCore.Entities;

public class Member : BaseEntity
{
    [Required]
    public string MemberName { get; set; }

}