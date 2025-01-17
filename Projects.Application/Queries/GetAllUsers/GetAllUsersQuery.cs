using MediatR;
using Projects.Domain.Entities;

namespace Projects.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
