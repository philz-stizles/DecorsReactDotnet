using AutoMapper;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Roles
{
    public class GetRole
    {
        public class Query : IRequest<RoleDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, RoleDto>
        {
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;

            public Handler(RoleManager<Role> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<RoleDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Check if role exists.
                var existingRole = await _roleManager.FindByIdAsync(request.Id.ToString());
                if (existingRole == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Role does not exist");
                }

                return _mapper.Map<RoleDto>(existingRole);
            }
        }
    }
}
