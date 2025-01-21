using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Infrastructure.Persistence.Repositories
{
    public class ActivityRepository(ProjetoDbContext context) : IActivityRepository
    {
        public async Task<int> AddProjectAsync(Atividade activity)
        {
            await context.Activitys.AddAsync(activity);

            context.SaveChanges();

            return activity.Id;
        }

        public async Task<List<Atividade>> GetAllActivitiesAsync()
        {
            var allActivity = await context.Activitys
                                     .Include(u => u.Client)
                                     .Include(p => p.ProjectName)
                                     .ToListAsync();

            return allActivity;
        }
    }
}
