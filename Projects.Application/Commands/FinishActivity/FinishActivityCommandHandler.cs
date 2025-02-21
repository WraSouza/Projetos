using MediatR;
using Projects.Domain.Repositories;

namespace Projects.Application.Commands.FinishActivity
{
    public class FinishActivityCommandHandler(IActivityRepository repository) : IRequestHandler<FinishActivityCommand, int>
    {
        public async Task<int> Handle(FinishActivityCommand request, CancellationToken cancellationToken)
        {
            var atividade = await repository.GetAllActivitiesAsync();
            

            foreach (var activity in atividade)
            {
                if(activity.Id == request.Id)
                {
                    activity.FinishActivity();

                    repository.FinishActivity(activity);

                    return activity.Id;
                }
            }            

            return 0;
        }
    }
}
