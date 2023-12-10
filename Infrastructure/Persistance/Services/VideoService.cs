using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Services
{
    public class VideoService : IVideoService
    {
        private readonly Cloudinary _cloudinary;
        public VideoService(IConfiguration config)
        {
            var acc = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]);
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<VideoUploadResult> AddVideoAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Crop("pad")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public Task<DeletionResult> DeleteVideoAsync(string publicid)
        {
            var deleteParams = new DeletionParams(publicid);
            var result = _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

    }
}
