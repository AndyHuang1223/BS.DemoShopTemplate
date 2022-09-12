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
            #region UserSeed
            builder.HasData(new User { Id = 1, Name = "AdminUser", Email = "AdminUser@gmail.com", Password = "AdminUser".ToSHA256(), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None });
            builder.HasData(new User { Id = 2, Name = "Developer", Email = "Developer@gmail.com", Password = "Developer".ToSHA256(), CreatedTime = DateTimeOffset.UtcNow, Gender = UserGender.None });
            #endregion
            builder.ToTable("Users");
        }
    }
}