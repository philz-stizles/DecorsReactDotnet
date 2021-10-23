using Decors.Application.Models;
using Decors.Application.Services.Coupons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class CouponsController: BaseController
    {
        public CouponsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CouponDto>))]
        public async Task<ActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetCoupons.Query());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CouponDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProduct(int id)
        {
            var result = await Mediator.Send(new GetCoupon.Query { Id = id });
            return Ok(result);
        }

        /*[HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CouponDto))]
        public async Task<ActionResult> CreateProduct(CreateCoupon.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CouponDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct(int id, UpdateCoupon.Command command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }*/
    }
}
