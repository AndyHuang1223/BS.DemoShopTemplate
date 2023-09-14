using BS.DemoShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.WebApi
{
  
    public class PhotoController : BaseApiController
    {
        private readonly IPhotoUploader _photoUploader;

        public PhotoController(IPhotoUploader photoUploader)
        {
            _photoUploader = photoUploader;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var result = await _photoUploader.UploadPhoto(file);
            return Ok(result);
        }
    }
}
