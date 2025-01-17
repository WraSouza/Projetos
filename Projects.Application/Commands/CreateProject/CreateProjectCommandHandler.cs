using MediatR;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler(IProjectRepository repository) : IRequestHandler<CreateProjectCommand, int>
    {
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.ProjectName, request.DeadLine, request.IdUser);

            int id = await repository.AddProjectAsync(project);

            return id;
        }
    }
}
