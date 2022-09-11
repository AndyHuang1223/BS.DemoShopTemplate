using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Entities
{
    public partial class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType RoleType { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }

    public enum RoleType
    {
        NormalUser = 0,
        Administrator = 1,
        Developer = 2
    }
}
