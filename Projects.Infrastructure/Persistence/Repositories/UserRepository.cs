using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;
using Projects.Domain.Repositories;

namespace Projects.Infrastructure.Persistence.Repositories
{
    public class UserRepository(ProjetoDbContext context) : IUserRepository
    {
        public async Task<int> AddUserAsync(User user)
        {
            //throw new NotImplementedException();
            await context.Users.AddAsync(user);

            context.SaveChanges();

            return user.Id;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            //throw new NotImplementedException();
            var users = await context.Users
                                .ToListAsync();

            return users;
        }
    }
}
