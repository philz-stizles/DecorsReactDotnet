using Decors.API.Filters;
using Decors.Application.Models;
using Decors.Application.Services.Vendors.Coupons;
using Decors.Application.Services.Vendors.Products;
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

        [HttpGet("{vendorId:int}/coupons")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<CouponDto>))]
        public async Task<ActionResult<List<CouponDto>>> GetCoupons([FromRoute] int vendorId)
        {
            var result = await Mediator.Send(new GetCoupons.Query
            {
                VendorId = vendorId,
            });
            return Ok(result);
        }

        [HttpGet("{vendorId:int}/coupons/{couponId:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CouponDto))]
        public async Task<ActionResult<CouponDto>> GetCoupon([FromRoute] int vendorId,
            [FromRoute] int couponId)
        {
            var result = await Mediator.Send(new GetCoupon.Query
            {
                VendorId = vendorId,
                CouponId = couponId
            });
            return Ok(result);
        }


        [HttpPost("{vendorId:int}/coupons")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CouponDto))]
        public async Task<ActionResult> CreateCoupon([FromRoute] int vendorId, CreateCoupon.Command command)
        {
            command.VendorId = vendorId;
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{vendorId:int}/coupons/{couponId:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateCoupon([FromRoute] int vendorId, int couponId, UpdateCoupon.Command command)
        {
            command.VendorId = vendorId;
            command.CouponId = couponId;
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{vendorId}/coupons/{couponId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> ArchiveCoupon([FromRoute] int vendorId, int couponId, ArchiveCoupon.Command command)
        {
            command.VendorId = vendorId;
            command.CouponId = couponId;
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("{vendorId}/locations")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CouponDto))]
        public async Task<ActionResult> CreateLocation([FromRoute] int vendorId, CreateCoupon.Command command)
        {
            command.VendorId = vendorId;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
