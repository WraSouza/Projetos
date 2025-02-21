using MediatR;
using Projects.Domain.Repositories;

namespace Projects.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler(IProjectRepository repository) : IRequestHandler<UpdateProjectCommand, int>
    {
        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await repository.GetProjectByIdAsync(request.Id);

            if(project is null)
            {
                throw new Exception("Project not found");
            }
            
            project.FinishProject();

            repository.UpdateProject(project);

            return project.Id;
           
        }
    }
}
