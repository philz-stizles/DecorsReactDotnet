using Decors.Application.Models.Dtos;
using Decors.Application.Services.Cart;
using Decors.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class CartController: BaseController
    {
        public CartController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cart))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CartDto))]
        public async Task<IActionResult> SaveCart(SaveCart.Command command)
        {

            var result = await Mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cart))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(CartDto))]
        public async Task<IActionResult> GetCart(string id)
        {
            var result = await Mediator.Send(new GetCart.Query {
                CartId = id
            });
            return Ok(result ?? new CartDto(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(string id)
        {
            var result = await Mediator.Send(new DeleteCart.Command
            {
                CartId = id
            });
            return Ok(result);
        }
    }
}
