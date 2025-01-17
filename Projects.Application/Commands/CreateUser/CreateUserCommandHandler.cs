using MediatR;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand, int>
    {
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var user = new User(request.FullName, request.Password, request.UserName);

            await repository.AddUserAsync(user);

            return user.Id;
        }
    }
}
