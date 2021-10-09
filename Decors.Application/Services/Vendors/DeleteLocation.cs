using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors
{
    public class DeleteLocation
    {
        public class Command : IRequest<ProductDto>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Category { get; set; }
            public decimal Price { get; set; }
        }

        public class Handler : IRequestHandler<Command, ProductDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IProductRepository _productRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, IProductRepository productRepository, 
                ICategoryRepository categoryRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _productRepository = productRepository;
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Map product dto to product entity.
                var newProduct = _mapper.Map<Product>(request);

                newProduct.Category = await _categoryRepository.GetByIdAsync(request.Category);

                // Create new product.
                var product = await _productRepository.AddAsync(newProduct);
                    
                return _mapper.Map<ProductDto>(product);
            }
        }
    }
}
