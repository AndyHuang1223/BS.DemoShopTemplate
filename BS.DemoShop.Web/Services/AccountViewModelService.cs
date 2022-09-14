using BS.DemoShop.Core.Entities;
using BS.DemoShop.Web.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BS.DemoShop.Web.Services
{
    public class AccountViewModelService : IAccountViewModelService
    {
        public IEnumerable<SelectListItem> GetUserGenderItems(UserGender? gender = null)
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "不透漏", Value = UserGender.None.ToString("D") },
                new SelectListItem() { Text = "男性", Value = UserGender.Male.ToString("D") },
                new SelectListItem() { Text = "女性", Value = UserGender.Male.ToString("D") }
            };

            if (gender.HasValue)
            {
                foreach (var item in items)
                {
                    item.Selected = item.Value == gender.Value.ToString("D");
                }
            }

            return items;
        }
    }
}
