using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Coupons
{
    public class GetCoupon
    {
        public class Query : IRequest<CouponDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CouponDto>
        {
            private readonly ICouponRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(ICouponRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<CouponDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve product if it exists.
                var existingCoupon = await _productRepository.GetByIdAsync(request.Id);
                if (existingCoupon  == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Coupon does not exist.");
                }

                return _mapper.Map<CouponDto>(existingCoupon);
            }
        }
    }
}
