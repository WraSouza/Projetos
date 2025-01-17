using MediatR;

namespace Projects.Application.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string ProjectName { get; set; }
        public DateTime DeadLine { get; set; }
        public int IdUser { get; set; }
    }
}
