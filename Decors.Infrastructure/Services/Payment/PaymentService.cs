using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Settings;
using Decors.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Payment
{
    public class PaymentService: IPaymentService
    {
        private readonly ICartRepository _cartRepository;
        private readonly StripeSettings _stripeSettings;

        public PaymentService(ICartRepository cartRepository, IOptions<StripeSettings> stripeOptions)
        {
            _cartRepository = cartRepository;
            _stripeSettings = stripeOptions.Value;
            _stripeSettings = stripeOptions.Value;
        }

        public Task<Cart> SavePaymentIntent(string cartId)
        {
            throw new System.NotImplementedException();
        }
    }
}
