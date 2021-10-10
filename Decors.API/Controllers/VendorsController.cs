using Decors.API.Filters;
using Decors.Application.Models;
using Decors.Application.Services.Vendors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    [Authorize(Roles = "Vendor")]
    [ServiceFilter(typeof(AuditFilterAttribute))]
    public class VendorsController: BaseController
    {
        public VendorsController(IMediator mediator) : base(mediator) { }

        [HttpGet("{vendorId:int}/products")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<ProductDto>))]
        public async Task<ActionResult<List<ProductDto>>> GetProducts([FromRoute] int vendorId)
        {
            var result = await Mediator.Send(new GetProducts.Query
            {
                VendorId = vendorId,
            });
            return Ok(result);
        }

        [HttpGet("{vendorId:int}/products/{productId:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int vendorId, 
            [FromRoute]  int productId)
        {
            var result = await Mediator.Send(new GetProduct.Query { 
                VendorId = vendorId,
                ProductId = productId
            });
            return Ok(result);
        }


        [HttpPost("{vendorId:int}/products")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        public async Task<ActionResult> CreateProduct([FromRoute] int vendorId, CreateProduct.Command command)
        {
            command.VendorId = vendorId;
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{vendorId:int}/products/{productId:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateProduct([FromRoute] int vendorId, int productId, UpdateProduct.Command command)
        {
            command.VendorId = vendorId;
            command.Id = productId;
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{vendorId}/products/{productId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int vendorId, int productId, UpdateProduct.Command command)
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
