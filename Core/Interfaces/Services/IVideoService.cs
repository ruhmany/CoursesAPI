using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Interfaces.Services
{
    public interface IVideoService
    {
        Task<VideoUploadResult> AddVideoAsync(IFormFile file);
        Task<DeletionResult> DeleteVideoAsync(string publicid);
    }
}
