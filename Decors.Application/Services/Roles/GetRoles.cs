using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Roles
{
    public class GetRoles
    {
        public class Query : IRequest<List<RoleDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<RoleDto>>
        {
            private readonly RoleManager<Role> _roleManager;
            private readonly IMapper _mapper;

            public Handler(RoleManager<Role> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<List<RoleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve existing roles.
                var roles = await Task.FromResult(_roleManager.Roles.ToList());

                return _mapper.Map<List<RoleDto>>(roles);
            }
        }
    }
}
