using AutoFixture;
using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Exceptions;
using Decors.Application.Mappers;
using Decors.Application.Services.Products;
using Decors.Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Decors.Tests.Application.Services.Products
{
    public class GetProductHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepoMoq;
        private readonly IMapper _mapper;
        private readonly Fixture _fixture;

        public GetProductHandlerTest()
        {
            _productRepoMoq = new Mock<IProductRepository>();
            _fixture = new Fixture();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
                cfg.AddProfile(new CategoryProfile());
            });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public async Task GetProduct_ReturnsItem()
        {
            //Arrange 
            var productMoq = _fixture.Create<Product>();
            _productRepoMoq
                .Setup(pr => pr.GetByIdAsync(productMoq.Id))
                .ReturnsAsync(() => productMoq);

            // Act
            var handler = new GetProduct.Handler(_productRepoMoq.Object, _mapper);
            var result = await handler.Handle(new GetProduct.Query { Id = productMoq.Id }, It.IsAny<CancellationToken>());


            // Assert
            Assert.NotNull(result);
            Assert.Equal(productMoq.Name, result.Name);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound()
        {
            //Arrange 
            var productMoq = _fixture.Create<Product>();
            _productRepoMoq
                .Setup(pr => pr.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var handler = new GetProduct.Handler(_productRepoMoq.Object, _mapper);

            // Assert
            var ex = await Assert.ThrowsAsync<RestException>(() => handler.Handle(new GetProduct.Query { Id = productMoq.Id },
                It.IsAny<CancellationToken>()));

            Assert.Equal("Product does not exist.", ex.Message);

            _productRepoMoq
                .Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
