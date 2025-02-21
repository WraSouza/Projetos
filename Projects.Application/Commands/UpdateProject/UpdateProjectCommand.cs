using MediatR;

namespace Projects.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public UpdateProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
