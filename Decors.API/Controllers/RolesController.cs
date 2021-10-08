using Decors.Application.Services.Roles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class RolesController: BaseController
    {
        public RolesController(IMediator mediator) : base(mediator) { }


        [HttpGet]
        public async Task<ActionResult> GetRoles(GetRole.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRole(Guid id)
        {
            var result = await Mediator.Send(new GetRole.Query { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRole(CreateRole.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(int id, UpdateRole.Command command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
