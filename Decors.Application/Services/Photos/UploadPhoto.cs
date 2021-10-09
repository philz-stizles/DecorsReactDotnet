using AutoMapper;
using Decors.Application.Contracts.Services;
using Decors.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Photos
{
    public class UploadPhoto
    {
        public class Command : IRequest<PhotoUploadResponseDto>
        {
            public IFormFile Photo { get; set; }
        }

        public class Handler : IRequestHandler<Command, PhotoUploadResponseDto>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            // private readonly IPhotoAccessor _photoAccessor;

            public Handler(IUserAccessor userAccessor, IMapper mapper) 
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
            }


            public async Task<PhotoUploadResponseDto> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
