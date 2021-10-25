using Decors.Domain.Entities;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Services
{
    public interface IPaymentService
    {
        Task<Cart> SavePaymentIntent(string cartId);
    }
}
