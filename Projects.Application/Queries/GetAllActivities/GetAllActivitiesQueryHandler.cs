using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetAllActivities
{
    public class GetAllActivitiesQueryHandler(IActivityRepository repository) : IRequestHandler<GetAllActivitiesQuery, List<ActivityViewModel>>
    {
        public async Task<List<ActivityViewModel>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            List<ActivityViewModel> activityViewModels = [];
           
            var allActivities = await repository.GetAllActivitiesAsync();

            foreach (var activity in allActivities)
            {
                ActivityViewModel viewModel = new ActivityViewModel(activity.Id,activity.IdProject, activity.ActivityName,activity.Client.FullName, activity.ProjectName.ProjectName,activity.DeadLine,activity.FinishedAt, activity.IsActive);

                activityViewModels.Add(viewModel);
            }

            return activityViewModels;
        }
    }
}
