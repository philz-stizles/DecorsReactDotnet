using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Persistence.Context;

namespace Decors.Persistence.Repositories
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataDbContext dbContext) : base(dbContext)
        {
        }
    }
}
