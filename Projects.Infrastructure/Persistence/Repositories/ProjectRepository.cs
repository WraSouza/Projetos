using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository(ProjetoDbContext context) : IProjectRepository
    {
        public async Task<int> AddProjectAsync(Project project)
        {            
            await context.Projects.AddAsync(project);

            context.SaveChanges();

            return project.Id;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {            
            var projects = await context.Projects                                        
                                        .Include(u => u.User)                                                                                                               
                                        .ToListAsync();

            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await context.Projects
                                       .Include(u => u.User)
                                       .FirstOrDefaultAsync(x => x.Id == id);

            return project;
        }

        public void UpdateProject(Project project)
        {
           context.Projects.Update(project);

            context.SaveChanges();
        }
    }
}
