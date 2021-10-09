using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors
{
    public class GetProduct
    {
        public class Query : IRequest<ProductDto>
        {
            public int VendorId { get; set; }
            public int ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IVendorRepository _vendorRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, IVendorRepository vendorRepository, 
                ICategoryRepository categoryRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _vendorRepository = vendorRepository;
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Products", false);
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor does not exist");
                }

                // Add product to vendor products.
                var vendorProduct = existingVendor.Products
                    .FirstOrDefault(p => p.Id == request.ProductId);
                if (vendorProduct == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Vendor product does not exist");
                }

                return _mapper.Map<ProductDto>(vendorProduct);
            }
        }
    }
}
