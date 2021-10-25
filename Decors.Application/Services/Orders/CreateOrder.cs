using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Orders
{
    public class CreateOrder
    {
        public class Command: IRequest
        {
            public int deliveryMethod { get; set; }
            public string CartId { get; set; }
            public int ShippingAddress{ get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly ICartRepository _cartRepository;
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, ICartRepository cartRepository,
                IProductRepository productRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _productRepository = productRepository;
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve customer cart.
                var cart = await _cartRepository.GetCartAsync(request.CartId);

                // Retrieve cart items from product repo.


                // Retrieve delivery method from delivery metod repo
                return Unit.Value;
            }
        }

    }
}
