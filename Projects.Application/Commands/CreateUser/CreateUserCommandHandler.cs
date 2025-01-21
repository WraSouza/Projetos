using MediatR;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;
using Projects.Infrastructure.Auth;

namespace Projects.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository repository, IAuthService authService) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
             var hash = authService.ComputeHash(request.Password);
            
            //throw new NotImplementedException();
            var user = new User(request.FullName, hash, request.Email);

            await repository.AddUserAsync(user);

            return user.Id;
        }
    }
}
