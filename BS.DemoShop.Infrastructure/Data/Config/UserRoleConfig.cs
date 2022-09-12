using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder
                .ToTable("UserRoles");
            #region UserRoleSeed
            builder.HasData(new UserRole { Id = 1, RoleId = 1, UserId = 1 });
            builder.HasData(new UserRole { Id = 2, RoleId = 1, UserId = 2 });
            builder.HasData(new UserRole { Id = 3, RoleId = 2, UserId = 1 });
            builder.HasData(new UserRole { Id = 4, RoleId = 3, UserId = 2 });
            #endregion
        }
    }
}