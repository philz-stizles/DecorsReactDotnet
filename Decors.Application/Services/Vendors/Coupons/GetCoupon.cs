using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Coupons
{
    public class GetCoupon
    {
        public class Query : IRequest<CouponDto>
        {
            public int VendorId { get; set; }
            public int CouponId { get; set; }
        }

        public class Handler : IRequestHandler<Query, CouponDto>
        {
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;

            public Handler(IVendorRepository vendorRepository, 
                IMapper mapper)
            {
                _vendorRepository = vendorRepository;
                _mapper = mapper;
            }

            public async Task<CouponDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Coupons");
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Add product to vendor products.
                var vendorCoupon = existingVendor.Coupons
                    .FirstOrDefault(p => p.Id == request.CouponId);
                if (vendorCoupon == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor coupon does not exist");
                }

                return _mapper.Map<CouponDto>(vendorCoupon);
            }
        }
    }
}
