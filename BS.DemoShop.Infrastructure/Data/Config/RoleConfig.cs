using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .ToTable("Roles");
            #region RoleSeed
            builder.HasData(new Role { Id = 1, Name = Core.Constants.AuthorizationConstants.NormalUser, RoleType = RoleType.NormalUser });
            builder.HasData(new Role { Id = 2, Name = Core.Constants.AuthorizationConstants.Administrator, RoleType = RoleType.Administrator });
            builder.HasData(new Role { Id = 3, Name = Core.Constants.AuthorizationConstants.Developer, RoleType = RoleType.Developer });
            #endregion
        }
    }
}