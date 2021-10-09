using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors
{
    public class GetProducts
    {
        public class Query : IRequest<List<ProductDto>>
        {
            public int VendorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            private readonly IVendorRepository _vendorRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IVendorRepository vendorRepository, 
                ICategoryRepository categoryRepository, IMapper mapper)
            {
                _vendorRepository = vendorRepository;
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Products", false);
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Add product to vendor products.
                var vendorProducts = existingVendor.Products;
                return _mapper.Map<List<ProductDto>>(vendorProducts);
            }
        }
    }
}
