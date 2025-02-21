using Projects.Domain.Entities;

namespace Projects.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<int> AddProjectAsync(Project project);
        Task<List<Project>> GetAllProjectsAsync();
        void UpdateProject(Project project);
        Task<Project> GetProjectByIdAsync(int id);
    }
}
