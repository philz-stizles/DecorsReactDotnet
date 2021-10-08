using MediatR;

namespace Decors.API.Controllers
{
    public class CouponsController: BaseController
    {
        public CouponsController(IMediator mediator) : base(mediator) { }
    }
}
