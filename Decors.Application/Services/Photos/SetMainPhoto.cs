using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Decors.Application.Services.Photos
{
    public class SetMainPhoto
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Command>
        {

            public Handler()
            {
            }


            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
