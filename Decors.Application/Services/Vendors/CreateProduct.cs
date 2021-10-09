using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors
{
    public class CreateProduct
    {
        public class Command : IRequest<ProductDto>
        {
            public int VendorId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Category { get; set; }
            public decimal Price { get; set; }
        }

        public class Handler : IRequestHandler<Command, ProductDto>
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

            public async Task<ProductDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Products");
                if(existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }


                // Map product dto to product entity.
                var newProduct = _mapper.Map<Product>(request);
                newProduct.CreatedBy = _userAccessor.GetCurrentUserId();

                // Add product to vendor products.
                existingVendor.Products.Add(newProduct);

                // Save vendor.
                await _vendorRepository.UpdateAsync(existingVendor);
                    
                return _mapper.Map<ProductDto>(newProduct);
            }
        }
    }
}
