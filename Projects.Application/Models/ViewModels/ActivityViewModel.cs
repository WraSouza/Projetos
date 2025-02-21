using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class ActivityViewModel
    {
        public ActivityViewModel()
        {
            
        }
        public ActivityViewModel(int id,int idProject,string activityName, string userName, string projectName, DateTime deadLine, DateTime finishedAt, bool isActive)
        {
            Id = id;
            IdProject = idProject;
            ActivityName = activityName;
            UserName = userName;
            ProjectName = projectName;
            DeadLine = deadLine;
            FinishedAt = finishedAt;
            IsActive = isActive;
        }

        public int Id { get; private set; }
        public string ActivityName { get; private set; }
        public string UserName { get; private set; }
        public string ProjectName { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public DateTime DeadLine { get; private set; }
        public DateTime FinishedAt { get; private set; }
        public bool IsActive { get; private set; }
    }
}
