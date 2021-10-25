using Decors.Domain.Entities;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string cartId);
        Task<Cart> SaveCartAsync(Cart cart);
        Task<bool> DeleteCartAsync(string cartId);
    }
}
