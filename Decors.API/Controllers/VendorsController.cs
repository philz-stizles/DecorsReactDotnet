using Decors.Application.Models;
using Decors.Application.Services.Vendors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    [Authorize]
    public class VendorsController: BaseController
    {
        public VendorsController(IMediator mediator) : base(mediator) { }

        [HttpPost("{vendorId}/products")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        public async Task<ActionResult> CreateProduct([FromRoute] int vendorId, CreateProduct.Command command)
        {
            command.VendorId = vendorId;
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("{vendorId}/products/{productId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CreateProduct([FromRoute] int vendorId, int productId, UpdateProduct.Command command)
        {
            command.VendorId = vendorId;
            command.Id = productId;
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("{vendorId}/addresses")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        public async Task<ActionResult> CreateAddress([FromRoute] int vendorId, CreateProduct.Command command)
        {
            command.VendorId = vendorId;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
