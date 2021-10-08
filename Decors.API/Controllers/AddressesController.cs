using MediatR;

namespace Decors.API.Controllers
{
    public class AddressesController: BaseController
    {
        public AddressesController(IMediator mediator) : base(mediator) { }
    }
}
