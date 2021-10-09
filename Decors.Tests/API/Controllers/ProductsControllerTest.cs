using AutoFixture;
using Decors.API.Controllers;
using Decors.Application.Models;
using Decors.Application.Services.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Decors.Tests.API.Controllers
{
    public class ProductsControllerTest
    {
        private readonly ProductsController controller;
        private readonly Mock<IMediator> mediatorMoq;
        private readonly Fixture _fixture;

        public ProductsControllerTest()
        {
            mediatorMoq = new Mock<IMediator>();
            controller = new ProductsController(mediatorMoq.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetProducts_ReturnsList()
        {
            //Arrange 
            var productDtoMoq = new List<ProductDto>();
            _fixture.AddManyTo(productDtoMoq);
            mediatorMoq
                .Setup(x => x.Send(It.IsAny<GetProducts.Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => productDtoMoq);

            // Act
            var result = await controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProductDto>>(okResult.Value);

            Assert.Equal(productDtoMoq.Count(), returnValue.Count());
        }

        [Fact]
        public async Task GetProduct_ReturnsItem()
        {
            //Arrange 
            var productDtoMoq = _fixture.Create<ProductDto>();
            mediatorMoq
                .Setup(x => x.Send( It.IsAny<GetProduct.Query>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => productDtoMoq);

            // Act
            var result = await controller.GetProduct(productDtoMoq.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProductDto>(okResult.Value);

            Assert.Equal(productDtoMoq.Name, returnValue.Name);
            Assert.Equal(productDtoMoq.Description, returnValue.Description);
            Assert.Equal(productDtoMoq.Price, returnValue.Price);
        }
    }
}
