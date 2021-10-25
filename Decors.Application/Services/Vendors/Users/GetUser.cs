using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Users
{
    public class GetUser
    {
        public class Query : IRequest<UserDto>
        {
            public int VendorId { get; set; }
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, IVendorRepository vendorRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _vendorRepository = vendorRepository;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Users");
                if (existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Retrieve vendor users.
                var vendorUsers = existingVendor.Users;

                // Verify requesting user.
                var existingUser = vendorUsers.FirstOrDefault(u => u.UserId.ToString() == _userAccessor.GetCurrentUserId());
                if (existingUser == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                // Verify target user.
                var targetUser = vendorUsers.FirstOrDefault(u => u.UserId == request.UserId);
                if (targetUser == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "User does not exist");
                }


                return _mapper.Map<UserDto>(targetUser);
            }
        }
    }
}
