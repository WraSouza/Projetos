using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Infrastructure.Persistence.Repositories
{
    public class UserRepository(ProjetoDbContext context) : IUserRepository
    {
        public async Task<int> AddUserAsync(User user)
        {
            
            await context.Users.AddAsync(user);

            context.SaveChanges();

            return user.Id;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
           
            var users = await context.Users
                                .ToListAsync();

            return users;
        }
    }
}
