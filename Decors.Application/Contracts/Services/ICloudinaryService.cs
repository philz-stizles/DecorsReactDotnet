using Decors.Application.Models;
using Decors.Application.Models.Responses;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Services
{
    public interface ICloudinaryService
    {
        Task<ServiceResponse<FileUploadResponseDto>> UploadFileAsync(IFormFile file);
    }
}
