using MediatR;

namespace Decors.API.Controllers
{
    public class OrdersController: BaseController
    {
        public OrdersController(IMediator mediator) : base(mediator) { }
    }
}
