using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {           
            List<UserViewModel> users = [];

            var allUsers = await repository.GetAllUsersAsync();

            foreach (var user in allUsers)
            {
                UserViewModel newUser = new UserViewModel(user.Id, user.FullName,user.Email, user.Projects, user.Atividades);

                users.Add(newUser);
            }

            return users;
        }
    }
}
