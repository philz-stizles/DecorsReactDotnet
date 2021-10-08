using MediatR;

namespace Decors.API.Controllers
{
    public class CategoriesController: BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator) { }
    }
}
