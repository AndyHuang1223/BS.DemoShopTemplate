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
                .Property(r => r.RoleType)
                .HasComment(" 0:NormalUser, 1:Administrator, 2:Developer");
            
            builder
                .ToTable("Roles");
            
        }
    }
}