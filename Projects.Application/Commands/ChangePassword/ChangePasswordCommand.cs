using MediatR;

namespace Projects.Application.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<int>
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}