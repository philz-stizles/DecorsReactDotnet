using Decors.Application.Models;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Services
{
    public interface IGeoLocationService
    {
        Task<GeoInfoDto> GetGeoInfo();
    }
}
