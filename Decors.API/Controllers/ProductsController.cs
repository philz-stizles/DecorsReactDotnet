using Decors.Application.Services.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class ProductsController: BaseController
    {
        public ProductsController(IMediator mediator): base(mediator) {}

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetProducts.Query());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetProduct( int id)
        {
            var result = await Mediator.Send(new GetProduct.Query { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProduct.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProduct.Command command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
