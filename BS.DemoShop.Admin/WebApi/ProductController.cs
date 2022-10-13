using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Admin.BaseModels;
using BS.DemoShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Admin.WebApi
{
    public class ProductController : BaseApiController
    {
        private readonly IProductQueryService _productQueryService;

        public ProductController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<BaseApiResponse> GetProductTotalInventory(int productId)
        {
            var result = await _productQueryService.GetProductTotalInventoryById(productId);
            return new BaseApiResponse(new {Inventory = result});
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<BaseApiResponse> GetProductMaxPriceById(int productId)
        {
            var result = await _productQueryService.GetProductMaxPriceById(productId);
            return new BaseApiResponse(new { MaxPrice = result });
        }
    }
}