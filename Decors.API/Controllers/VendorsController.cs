using MediatR;

namespace Decors.API.Controllers
{
    public class VendorsController: BaseController
    {
        public VendorsController(IMediator mediator) : base(mediator) { }
    }
}
