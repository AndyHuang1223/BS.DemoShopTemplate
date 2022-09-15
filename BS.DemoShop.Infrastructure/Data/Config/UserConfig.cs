using System;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Extensions;
using BS.DemoShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public UserConfig()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Email)
                .HasMaxLength(500);
            builder
                .Property(u => u.Password)
                .HasMaxLength(4000);
            builder
                .ToTable("Users");
        }
    }
}