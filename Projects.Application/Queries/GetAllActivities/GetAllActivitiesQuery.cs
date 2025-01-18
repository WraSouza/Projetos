using MediatR;
using Projects.Application.Models.ViewModels;

namespace Projects.Application.Queries.GetAllActivities
{
    public class GetAllActivitiesQuery: IRequest<List<ActivityViewModel>>
    {
    }
}
