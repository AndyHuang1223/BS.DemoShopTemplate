using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IPhotoUploader
    {
        /// <summary>
        /// 上傳圖片
        /// </summary>
        /// <param name="photo"></param>
        /// <returns>圖片 Uri</returns>
        Task<string> UploadPhoto(IFormFile photo);
    }
}
