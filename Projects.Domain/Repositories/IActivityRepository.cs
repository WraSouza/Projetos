

using Projects.Domain.Entities;

namespace Projects.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<int> AddProjectAsync(Atividade activity);
        Task<List<Atividade>> GetAllActivitiesAsync();
    }
}
