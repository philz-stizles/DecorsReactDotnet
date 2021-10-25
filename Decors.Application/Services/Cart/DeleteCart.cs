using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Cart
{
    public class DeleteCart
    {
        public class Command : IRequest
        {
            public string CartId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICartRepository _cartRepository;
            private readonly IMapper _mapper;

            public Handler(ICartRepository cartRepository, IMapper mapper)
            {
                _cartRepository = cartRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _cartRepository.DeleteCartAsync(request.CartId);

                return Unit.Value;
            }
        }
    }
}

