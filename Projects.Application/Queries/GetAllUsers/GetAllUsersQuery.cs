using MediatR;
using Projects.Application.Models.ViewModels;

namespace Projects.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
    }
}
