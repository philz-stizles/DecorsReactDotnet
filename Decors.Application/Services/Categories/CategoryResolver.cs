//using AutoMapper;
//using Decors.Application.Contracts.Repositories;
//using Decors.Application.Services.Products;
//using Decors.Domain.Entities;

//namespace Decors.Application.Services.Categories
//{
//    public class CategoryResolver : IValueResolver<CreateProduct.Command, Product, Category>
//    {
//        private readonly ICategoryRepository _categoryRepository;

//        public CategoryResolver(ICategoryRepository categoryRepository)
//        {
//            _categoryRepository = categoryRepository;
//        }

//        public Category Resolve(CreateProduct.Command source, Product destination, 
//            Category destMember, ResolutionContext context)
//        {
//            return _categoryRepository.GetByIdAsync(source.Category);
//        }
//    }
//}
