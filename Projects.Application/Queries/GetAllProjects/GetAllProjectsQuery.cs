using MediatR;
using Projects.Application.Models.ViewModels;

namespace Projects.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }
}
