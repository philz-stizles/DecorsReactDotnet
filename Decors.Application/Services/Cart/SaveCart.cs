using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Cart
{
    public class SaveCart
    {
        public class Command: IRequest<CartDto>
        {
            public string Id { get; set; } // This will be generated from the client-side
            public decimal TotalAmount { get; set; }
            public decimal TotalAfterDiscount { get; set; }
            public virtual List<CartItemDto> Items { get; set; }
        }

        public class Handler : IRequestHandler<Command, CartDto>
        {
            private readonly ICartRepository _cartRepository;
            private readonly IMapper _mapper;

            public Handler(ICartRepository cartRepository, IMapper mapper)
            {
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<CartDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Mapper cart dto to cart entity.
                var newCart = _mapper.Map<Domain.Entities.Cart>(request);

                // Save cart.
                var savedCart = await _cartRepository.SaveCartAsync(newCart);

                return _mapper.Map<CartDto>(savedCart);
            }
        }
    }
}
