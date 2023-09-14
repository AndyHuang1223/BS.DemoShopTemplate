using BS.DemoShop.Core.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Services
{
    public class CloudinaryPhotoUploader : IPhotoUploader
    {
        private const string _tags = "backend_PhotoAlbum";
        private readonly Cloudinary _cloudinary;

        public CloudinaryPhotoUploader(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadPhoto(IFormFile photo)
        {
            if (photo is null || photo.Length == 0)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            var result = await _cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(photo.FileName, photo.OpenReadStream()),
                Tags = _tags
            }).ConfigureAwait(false);
            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            return result.SecureUrl.ToString();
        }
    }
}
