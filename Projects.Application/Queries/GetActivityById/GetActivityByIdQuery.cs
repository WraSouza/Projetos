using MediatR;
using Projects.Application.Models.ViewModels;
using Projects.Domain.Entities;

namespace Projects.Application.Queries.GetActivityById
{
    public class GetActivityByIdQuery : IRequest<List<ActivityViewModel>>
    {
        public GetActivityByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get;  set; }
        public string ActivityName { get;  set; }
        public string UserName { get;  set; }
        public string ProjectName { get; set; }
        public int IdProject { get; set; }
        public Project Project { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
