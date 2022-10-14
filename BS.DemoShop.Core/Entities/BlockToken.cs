using System;

namespace BS.DemoShop.Core.Entities
{
    public class BlockToken : BaseEntity
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTimeOffset ExpireTime { get; set; }
    }
}