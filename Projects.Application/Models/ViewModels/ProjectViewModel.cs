using Projects.Domain.Entities;

namespace Projects.Application.Models.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string fullName)
        {
            ProjectName = fullName;
        }

        public string ProjectName { get; set; }

        public static ProjectViewModel FromEntity(Project entity)
            => new(entity.ProjectName);

        
    }
}
