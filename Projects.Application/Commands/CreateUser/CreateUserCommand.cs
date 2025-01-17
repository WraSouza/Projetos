using MediatR;

namespace Projects.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {        
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
