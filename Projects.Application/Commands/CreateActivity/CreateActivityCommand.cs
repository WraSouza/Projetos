using MediatR;

namespace Projects.Application.Commands.CreateActivity
{
    public class CreateActivityCommand : IRequest<int>
    {        
        public string ActivityName {  get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
