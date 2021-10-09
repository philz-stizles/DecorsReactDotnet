using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Exceptions;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Vendors
{
    public class UpdateProduct
    {
        public class Command : IRequest
        {
            public int VendorId { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int CategoryId { get; set; }
            public decimal Price { get; set; }
        }

        public class Handler : IRequestHandler<Command>
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

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // Retrieve vendor if it exists.
                var existingVendor = await _vendorRepository.GetByIdAsync(request.VendorId, "Products", false);
                if (existingVendor == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Retrieve product if it exists.
                var existingProduct = existingVendor.Products.SingleOrDefault(p => p.Id == request.Id);
                if (existingProduct == null)
                {
                    throw new RestException(HttpStatusCode.NotFound);
                }

                // Update exisiting product.
                existingProduct.Name = request.Name;
                existingProduct.Description= request.Description;
                existingProduct.Price = request.Price;
                existingProduct.LastModifiedBy = _userAccessor.GetCurrentUserId();

                if(existingProduct.Category == null || (existingProduct.Category == null && existingProduct.Category.Id != request.CategoryId))
                {
                    // Retrieve category if it exists.
                    var existingCategory = await _categoryRepository.GetByIdAsync(request.CategoryId);
                    if (existingCategory != null)
                    {
                        existingProduct.Category = existingCategory;
                    }
                }

                // Save vendor.
                await _vendorRepository.UpdateAsync(existingVendor);

                return Unit.Value;
            }
        }
    }
}
