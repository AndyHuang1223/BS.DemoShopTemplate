using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Entities
{
    public partial class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserGender Gender { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }

    public enum UserGender
    {
        None = 0,
        Male = 1,
        Female = 2
    }
}
