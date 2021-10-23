using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using Decors.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Categories
{
    public class CreateCategory
    {
        public class Command : IRequest<CategoryDto>
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Command, CategoryDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly ICategoryRepository _productRepository;
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(IUserAccessor userAccessor, ICategoryRepository productRepository, 
                ICategoryRepository categoryRepository, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _productRepository = productRepository;
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CategoryDto> Handle(Command request, CancellationToken cancellationToken)
            {
                // Map category dto to category entity.
                var newCategory = _mapper.Map<Category>(request);

                var category = await _categoryRepository.AddAsync(newCategory);
                    
                return _mapper.Map<CategoryDto>(category);
            }
        }
    }
}
