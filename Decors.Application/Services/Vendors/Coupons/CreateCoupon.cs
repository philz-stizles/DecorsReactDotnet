using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Coupons
{
    public class CreateCoupon
    {
        public class Command : IRequest<CouponDto>
        {
            [JsonIgnore]
            public int VendorId { get; set; }
            public string Code { get; set; }
            public int Discount { get; set; }
            public DateTime Expires { get; set; }
        }

        public class Handler : IRequestHandler<Command, CouponDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, IVendorRepository vendorRepository, 
                IMapper mapper)
            {
                _userAccessor = userAccessor;
                _vendorRepository = vendorRepository;
                _mapper = mapper;
            }

            public async Task<CouponDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Coupons", false);
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }


                // Map coupon dto to coupon entity.
                var newCoupon = _mapper.Map<Coupon>(request);
                newCoupon.CreatedBy = _userAccessor.GetCurrentUserId();
                newCoupon.CreatedDate = DateTime.Now;

                // Check if a coupon with the given name already exists.
                var existingCoupon = existingVendor.Coupons.FirstOrDefault(p => p.Code == newCoupon.Code);
                if (existingCoupon != null)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "A coupon with the given code already exists");
                }

                // Add coupon to vendor coupons.
                existingVendor.Coupons.Add(newCoupon);

                // Save vendor.
                await _vendorRepository.UpdateAsync(existingVendor);
                    
                return _mapper.Map<CouponDto>(newCoupon);
            }
        }
    }
}
