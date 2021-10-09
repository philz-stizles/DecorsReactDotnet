using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Storage
{
    public class PhotoAccessor : IPhotoAccessor
    {
        public Task<string> DeleteFileAsync(string publicId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFileAsync(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFilesAsync(List<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }
    }
}
