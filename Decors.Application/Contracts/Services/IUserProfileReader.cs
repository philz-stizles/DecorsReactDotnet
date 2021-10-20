using Decors.Application.Models;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Services
{
    public interface IUserProfileReader
    {
        Task<UserProfileDto> ReadProfile(string username);
    }
}
