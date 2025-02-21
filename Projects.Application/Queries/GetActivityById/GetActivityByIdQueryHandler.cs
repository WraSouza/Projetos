using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetActivityById
{
    public class GetActivityByIdQueryHandler(IActivityRepository activityRepository) : IRequestHandler<GetActivityByIdQuery, List<ActivityViewModel>>
    {
        public async Task<List<ActivityViewModel>> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
        { 
            var allActivities = await activityRepository.GetActivityByIdAsync(request.Id);

            if(allActivities != null)
            {
                ActivityViewModel activityViewModels = new(allActivities.Id, allActivities.IdProject,
                                                             allActivities.ActivityName,
                                                              allActivities.Client.FullName,
                                                               allActivities.ProjectName.ProjectName,
                                                                allActivities.DeadLine,
                                                                 allActivities.FinishedAt,
                                                                 allActivities.IsActive);
            }             

            return null;

            
        }
    }
}
