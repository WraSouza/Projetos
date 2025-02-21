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

        public void FinishActivity(Atividade activity)
        {
            context.Activitys.Update(activity);

            context.SaveChanges();
        }

        public async Task<Atividade> GetActivityByIdAsync(int id)
        {
            var allActivity =  await context.Activitys
                                    .Include(u => u.Client)
                                    .Include(p => p.ProjectName)
                                    .SingleOrDefaultAsync(x => x.IdUser == id);

            return allActivity;
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
