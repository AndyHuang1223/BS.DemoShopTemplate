using BS.DemoShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BS.DemoShop.Infrastructure.Services
{
    public class SHA256Hasher : IAppPasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] source = Encoding.Default.GetBytes(password);
            using (var mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(source);
                string result = hashValue.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
                return result.ToUpper();
            }
        }
    }
}
