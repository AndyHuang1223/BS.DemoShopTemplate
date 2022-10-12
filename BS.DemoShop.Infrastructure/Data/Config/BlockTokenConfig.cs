using BS.DemoShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BS.DemoShop.Infrastructure.Data.Config
{
    public class BlockTokenConfig : IEntityTypeConfiguration<BlockToken>
    {
        public void Configure(EntityTypeBuilder<BlockToken> builder)
        {
            builder
                .ToTable("BlockTokens");
        }
    }
}