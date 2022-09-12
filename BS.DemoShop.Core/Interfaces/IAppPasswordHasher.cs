using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IAppPasswordHasher
    {
        string HashPassword(string password);
    }
}
