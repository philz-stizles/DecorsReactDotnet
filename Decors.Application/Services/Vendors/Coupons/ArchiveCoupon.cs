using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Coupons
{
    public class ArchiveCoupon
    {
        public class Command : IRequest<CouponDto>
        {
            public int VendorId { get; set; }
            public int CouponId { get; set; }
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
                List<Expression<Func<Vendor, object>>> includes = new List<Expression<Func<Vendor, object>>>();
                includes.Add(v => v.Coupons);
                includes.Add(v => v.Users);
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, includes, false);
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Verify user.
                var existingUser = existingVendor.Users.FirstOrDefault(u => u.UserId.ToString() == _userAccessor.GetCurrentUserId());
                if (existingUser == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }


                // Retrieve coupon if exists.
                var existingCoupon = existingVendor.Coupons.FirstOrDefault(c => c.Id == request.CouponId);
                if (existingCoupon == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }
                
                // Update Coupon.
                existingCoupon.IsActive = false;
                existingCoupon.LastModifiedBy = _userAccessor.GetCurrentUserId();
                existingCoupon.LastModifiedDate = DateTime.Now;

                // Save vendor.
                await _vendorRepository.UpdateAsync(existingVendor);
                    
                return _mapper.Map<CouponDto>(existingCoupon);
            }
        }
    }
}
