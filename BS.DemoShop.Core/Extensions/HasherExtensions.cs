using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BS.DemoShop.Core.Extensions
{
    public static class HasherExtensions
    {
        public static string ToSHA256(this string origin)
        {
            byte[] source = Encoding.Default.GetBytes(origin);
            using (var mySHA256 = SHA256.Create())
            {
                byte[] hashValue = mySHA256.ComputeHash(source);
                string result = hashValue.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
                return result.ToUpper();
            }
        }
    }
}
