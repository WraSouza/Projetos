﻿using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Repositories;

namespace Projects.Application.Queries.GetAllActivities
{
    public class GetAllActivitiesQueryHandler(IActivityRepository repository) : IRequestHandler<GetAllActivitiesQuery, List<ActivityViewModel>>
    {
        public async Task<List<ActivityViewModel>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            List<ActivityViewModel> activityViewModels = [];
            //throw new NotImplementedException();
            var allActivities = await repository.GetAllActivitiesAsync();

            foreach (var activity in allActivities)
            {
                ActivityViewModel viewModel = new ActivityViewModel(activity.ActivityName,activity.Client.FullName, activity.ProjectName.ProjectName,activity.DeadLine);

                activityViewModels.Add(viewModel);
            }

            return activityViewModels;
        }
    }
}
