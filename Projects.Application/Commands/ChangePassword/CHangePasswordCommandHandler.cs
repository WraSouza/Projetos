
using MediatR;

namespace Projects.Application.Commands.ChangePassword
{
    public class CHangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, int>
    {
        public Task<int> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}