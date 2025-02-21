using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string projectName, string userName, DateTime finishedAt, DateTime deadLine, int idUser, int id,bool isFinished, DateTime createdAt)
        {
            ProjectName = projectName;
            UserName = userName;
            FinishedAt = finishedAt;
            DeadLine = deadLine;
            IdUser = idUser;     
            Id = id;      
            IsFinished = isFinished;
            CreatedAt = createdAt;
        }

        public int Id { get; private set; }
        public string ProjectName { get; private set; }
        public string UserName { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public DateTime DeadLine { get; private set; }
        //public User User { get; private set; }
        public int IdUser { get; private set; }
        public bool IsFinished { get; private set; }
        public DateTime CreatedAt { get; private set; }


        public static ProjectViewModel FromEntity(Project entity)
            => new(entity.ProjectName, entity.User.FullName, entity.FinishedAt, entity.DeadLine, entity.IdUser, entity.Id, entity.IsFinished, entity.CreatedAt);

        
    }
}
