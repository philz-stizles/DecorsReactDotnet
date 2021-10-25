using Decors.Domain.Entities;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Repositories
{
    public interface IVendorRepository : IAsyncRepository<Vendor>
    {
        Task<Vendor> GetByIdIncludeUser(int vendorId);
    }
}
