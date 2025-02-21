using Projects.Domain.Entities;

namespace Projects.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        //bool ChangePassword();
    }
}
