using BS.DemoShop.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BS.DemoShop.Web.Interfaces
{
    public interface IAccountViewModelService
    {
        IEnumerable<SelectListItem> GetUserGenderItems(UserGender? gender = null);
    }
}
