using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class VendorRepository: RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
