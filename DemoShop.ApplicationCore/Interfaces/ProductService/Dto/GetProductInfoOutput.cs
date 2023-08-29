using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShop.ApplicationCore.Interfaces.ProductService.Dto
{
    public class GetProductInfoOutput
    {
        /// <summary>
        /// 顯示預設價格
        /// </summary>
        public decimal ShowPrice { get; set; }

        //TODO 還要傳出去的欄位
    }
}
