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
                .Property(ur => ur.RoleId)
                .IsRequired();
            builder
                .Property(ur => ur.RoleId)
                .IsRequired();
            
            builder
                .ToTable("UserRoles");
        }
    }
}