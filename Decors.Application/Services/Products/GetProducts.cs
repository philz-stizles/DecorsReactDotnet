using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Products
{
    public class GetProducts
    {
        public class Query : IRequest<List<ProductDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public Handler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve products
                var products = await _productRepository.GetAllAsync();
                    
                return _mapper.Map<List<ProductDto>>(products);
            }
        }
    }
}
