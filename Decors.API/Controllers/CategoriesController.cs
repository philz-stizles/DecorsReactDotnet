using Decors.Application.Models;
using Decors.Application.Services.Categories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class CategoriesController: BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoryDto>))]
        public async Task<ActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetCategories.Query());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProduct(int id)
        {
            var result = await Mediator.Send(new GetCategory.Query { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoryDto))]
        public async Task<ActionResult> CreateProduct(CreateCategory.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct(int id, UpdateCategory.Command command)
        {
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
