using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string fullName, string userName)
        {
            ProjectName = fullName;
            UserName = userName;
        }

        public string ProjectName { get; private set; }
        public string UserName { get; private set; }

        public static ProjectViewModel FromEntity(Project entity)
            => new(entity.ProjectName, entity.User.FullName);

        
    }
}
