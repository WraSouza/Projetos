using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository(ProjetoDbContext context) : IProjectRepository
    {
        public async Task<int> AddProjectAsync(Project project)
        {
            //throw new NotImplementedException();
            await context.Projects.AddAsync(project);

            context.SaveChanges();

            return project.Id;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            //throw new NotImplementedException();
            var projects = await context.Projects
                                        .Include(u => u.User)
                                        .Where(p => p.IsActive == true)
                                        .ToListAsync();

            return projects;
        }
    }
}
