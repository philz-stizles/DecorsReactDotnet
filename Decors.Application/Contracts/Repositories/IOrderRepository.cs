using Decors.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Repositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
