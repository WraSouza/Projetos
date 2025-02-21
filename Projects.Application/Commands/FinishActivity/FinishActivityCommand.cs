using MediatR;

namespace Projects.Application.Commands.FinishActivity
{
    public class FinishActivityCommand : IRequest<int>
    {
        public FinishActivityCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
