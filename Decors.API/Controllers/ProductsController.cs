using Decors.API.Filters;
using Decors.Application.Models;
using Decors.Application.Services.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    [ServiceFilter(typeof(AuditFilterAttribute))]
    public class ProductsController: BaseController
    {
        public ProductsController(IMediator mediator): base(mediator) {}

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDto>))]
        public async Task<ActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProducts.Query());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProduct( int id)
        {
            var result = await Mediator.Send(new GetProduct.Query { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductDto))]
        public async Task<ActionResult> CreateProduct(CreateProduct.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProduct.Command command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
