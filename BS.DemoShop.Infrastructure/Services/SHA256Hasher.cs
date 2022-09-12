using BS.DemoShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BS.DemoShop.Core.Extensions;

namespace BS.DemoShop.Infrastructure.Services
{
    public class SHA256Hasher : IAppPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password.ToSHA256();
        }
    }
}
