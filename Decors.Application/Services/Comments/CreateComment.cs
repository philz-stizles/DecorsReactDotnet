using MediatR;

namespace Decors.Application.Services.Comments
{
    public class CreateComment
    {
        public class Command: IRequest
        {
            public string Username { get; set; }
        }
    }
}
