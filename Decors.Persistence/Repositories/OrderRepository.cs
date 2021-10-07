using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.Persistence.Repositories
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(DataDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
