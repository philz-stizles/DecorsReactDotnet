using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Coupons
{
    public class GetCoupons
    {
        public class Query : IRequest<List<CouponDto>>
        {
            public int VendorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<CouponDto>>
        {
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;

            public Handler(IVendorRepository vendorRepository, IMapper mapper)
            {
                _vendorRepository = vendorRepository;
                _mapper = mapper;
            }

            public async Task<List<CouponDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Coupons");
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Add product to vendor products.
                var vendorCoupons = existingVendor.Coupons;
                return _mapper.Map<List<CouponDto>>(vendorCoupons);
            }
        }
    }
}
