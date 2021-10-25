using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;
using Decors.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Decors.Tests.Infrastructure.Repositories
{
    public class ProductRepositoryTest
    {
        // private Mock<IProductRepository> _productRepository;

        [Fact]
        public void Setup()
        {
            // _productRepository = new Mock<IProductRepository>();
        }

        [Fact]
        /*public void Add_ProductObjectPassed_ProperMethodCalled()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<DataDbContext>();
            var dbSetMock = new Mock<DbSet<Product>>();
            var newProduct = new Product();
            dbSetMock.Setup(s => s.Add(newProduct)).Returns();
            dbContextMock.Setup(s => s.Set<Product>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var productRepository = new ProductRepository(dbContextMock.Object);
            var createdProduct = productRepository.AddAsync(new Product()).Result;

            //Assert  
            // productRepositoryMock.Verify(); //verify that GetByID was called based on setup.
            Assert.NotNull(createdProduct);
            Assert.IsAssignableFrom<Product>(createdProduct);
            Assert.Equal(newProduct, createdProduct); //assert that actual result was as expected
        }*/
    }
}
