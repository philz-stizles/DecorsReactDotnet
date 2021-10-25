using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Cart
{
    public class GetCart
    {
        public class Query: IRequest<CartDto>
        {
            public string CartId { get; set; }
        }

        public class Handler : IRequestHandler<Query, CartDto>
        {
            private readonly ICartRepository _cartRepository;
            private readonly IMapper _mapper;

            public Handler(ICartRepository cartRepository, IMapper mapper)
            {
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<CartDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var cart = await _cartRepository.GetCartAsync(request.CartId);

                return _mapper.Map<CartDto>(cart);
            }
        }
    }
}
