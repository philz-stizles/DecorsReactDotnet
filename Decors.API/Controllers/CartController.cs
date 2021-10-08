using MediatR;

namespace Decors.API.Controllers
{
    public class CartController: BaseController
    {
        public CartController(IMediator mediator) : base(mediator) { }
    }
}
