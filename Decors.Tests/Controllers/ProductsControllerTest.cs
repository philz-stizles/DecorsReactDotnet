using AutoFixture;
using Decors.API.Controllers;
using Decors.Application.Models;
using Decors.Application.Services.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Decors.Tests
{
    public class ProductsControllerTest
    {
        private readonly ProductsController _controller;
        private readonly Mock<IMediator> mediatorMoq;

        public ProductsControllerTest()
        {
            mediatorMoq = new Mock<IMediator>();
            _controller = new ProductsController(mediatorMoq.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Arrange
            var fixture = new Fixture();
            var id = 1;
            var productDtoMoq = fixture.Create<ProductDto>();
            mediatorMoq
                .Setup(x => x.Send(new GetProduct.Query { Id = id }, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productDtoMoq));

            // Act
            Task.Run(async () =>
            {
                var result = await _controller.GetProduct(id);

                // Assert
                Assert.IsType<OkObjectResult>(result as OkObjectResult);
            }).GetAwaiter().GetResult(); 
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsItem()
        {
            //Arrange
            var fixture = new Fixture();
            var id = 1;
            var productDtoMoq = fixture.Create<ProductDto>();
            mediatorMoq
                .Setup(x => x.Send(new GetProduct.Query { Id = id }, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productDtoMoq));

            // Act
            var result = await _controller.GetProduct(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(productDtoMoq.Name, returnValue.Name);
        }
    }
}
