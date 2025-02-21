using MediatR;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Application.Commands.CreateActivity
{
    public class CreateActivityCommandHandler(IActivityRepository repository) : IRequestHandler<CreateActivityCommand, int>
    {
        public async Task<int> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {           
            var activity = new Atividade(request.ActivityName, request.DeadLine, request.IdUser, request.IdProject);

            int id = await repository.AddProjectAsync(activity);

            return id;
        }
    }
}
