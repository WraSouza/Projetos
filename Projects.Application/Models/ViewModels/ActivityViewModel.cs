using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class ActivityViewModel
    {
        public ActivityViewModel(string activityName, string userName, string projectName, DateTime deadLine)
        {
            ActivityName = activityName;
            UserName = userName;
            ProjectName = projectName;
            DeadLine = deadLine;
          
        }

        public string ActivityName { get; private set; }
        public string UserName { get; private set; }
        public string ProjectName { get; private set; }
        public DateTime DeadLine { get; private set; }
        public DateTime FinishedAt { get; private set; }
    }
}
