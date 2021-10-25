using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using Decors.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors.Users
{
    public class CreateUser
    {
        public class Command : IRequest<UserDto>
        {
            public int VendorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<User> _userManager;
            private readonly RoleManager<Role> _roleManager;
            private readonly IVendorRepository _vendorRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, UserManager<User> userManager,
                RoleManager<Role> roleManager, IMapper mapper, IVendorRepository vendorRepository)
            {
                _vendorRepository = vendorRepository;
                _userManager = userManager;
                _roleManager = roleManager;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Users", false);
                if (existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Map user dto to user entity.
                var newUser = _mapper.Map<User>(request);

                // Create new user.
                var result = await _userManager.CreateAsync(newUser, request.Password);
                if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new
                {
                    errors = string.Join(", ", result.Errors.Select(e => e.Description))
                });

                // Retrieve newly created user.
                var createdUser = await _userManager.FindByIdAsync(newUser.Id.ToString());

                // Assign roles to user.
                await _userManager.AddToRolesAsync(createdUser, new List<string> { RoleTypes.Vendor.ToString() });

                // Retrieve user roles.
                var userRoles = await _userManager.GetRolesAsync(createdUser);

                return _mapper.Map<UserDto>(createdUser);
            }
        }
    }
}
