using MediatR;

namespace Decors.API.Controllers
{
    public class CustomersController: BaseController
    {
        public CustomersController(IMediator mediator) : base(mediator) { }
    }
}
