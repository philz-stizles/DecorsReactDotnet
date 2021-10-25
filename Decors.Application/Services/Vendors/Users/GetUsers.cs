using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Users
{
    public class GetUsers
    {
        public class Query : IRequest<List<UserDto>>
        {
            public int VendorId { get; set; }
            public int Page { get; set; }
            public int Size { get; set; }
            public string Search { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<UserDto>>
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

            public async Task<List<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdIncludeUser(request.VendorId);
                if (existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Retrieve vendor users.
                var vendorUsers = existingVendor.Users;

                // Verify user.
                var existingUser = vendorUsers.FirstOrDefault(u => u.UserId.ToString() == _userAccessor.GetCurrentUserId());
                if (existingUser == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                return _mapper.Map<List<UserDto>>(vendorUsers);
            }
        }
    }
}
