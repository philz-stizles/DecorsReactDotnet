using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Persistence.Context;

namespace Decors.Persistence.Repositories
{
    public class VendorRepository: RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
