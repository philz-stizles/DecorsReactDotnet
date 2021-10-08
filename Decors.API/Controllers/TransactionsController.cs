using MediatR;

namespace Decors.API.Controllers
{
    public class TransactionsController: BaseController
    {
        public TransactionsController(IMediator mediator) : base(mediator) { }
    }
}
