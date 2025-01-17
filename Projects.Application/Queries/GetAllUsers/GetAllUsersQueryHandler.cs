using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Org.BouncyCastle.Tls;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            List<User> users = [];

            var allUsers = await repository.GetAllUsersAsync();

            foreach (var user in allUsers)
            {
                User newUser = new User(user.FullName, user.Password, user.UserName);

                users.Add(newUser);
            }

            return users;
        }
    }
}
