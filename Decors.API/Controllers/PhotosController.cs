using MediatR;

namespace Decors.API.Controllers
{
    public class PhotosController: BaseController
    {
        public PhotosController(IMediator mediator) : base(mediator) { }
    }
}
