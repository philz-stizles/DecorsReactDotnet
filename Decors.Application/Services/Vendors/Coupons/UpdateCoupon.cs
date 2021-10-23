using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Coupons
{
    public class UpdateCoupon
    {
        public class Command : IRequest
        {
            public int VendorId { get; set; }
            public int CouponId { get; set; }
            public string Code { get; set; }
            public int Discount { get; set; }
            public DateTime Expires { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IVendorRepository _vendorRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, IVendorRepository vendorRepository,
                ICategoryRepository categoryRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _vendorRepository = vendorRepository;
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if it exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Coupons", false);
                if (existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Retrieve coupon if it exists.
                var existingCoupon = existingVendor.Coupons.SingleOrDefault(c => c.Id == request.CouponId);
                if (existingCoupon == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Update exisiting coupon.
                existingCoupon.Code = request.Code;
                existingCoupon.Discount = request.Discount;
                existingCoupon.Expires = request.Expires;
                existingCoupon.LastModifiedBy = _userAccessor.GetCurrentUserId();

                // Save vendor.
                await _vendorRepository.UpdateAsync(existingVendor);

                return Unit.Value;
            }
        }
    }
}
