using AutoMapper;
using Decors.Application.Contracts.Repositories;
using Decors.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Coupons
{
    public class GetCoupons
    {
        public class Query : IRequest<List<CouponDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CouponDto>>
        {
            private readonly ICouponRepository _categoryRepository;
            private readonly IMapper _mapper;

            public Handler(ICouponRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<List<CouponDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Retrieve categorys
                var categorys = await _categoryRepository.GetAllAsync();
                    
                return _mapper.Map<List<CouponDto>>(categorys);
            }
        }
    }
}
