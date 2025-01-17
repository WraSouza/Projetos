using Microsoft.EntityFrameworkCore;
using Projects.Domain.Entities;

namespace Projects.Infrastructure.Persistence
{
    public class ProjetoDbContext : DbContext
    {
        public ProjetoDbContext(DbContextOptions<ProjetoDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Pessoa>(u =>
                {
                    u.HasKey(u => u.Id);
                });

            base.OnModelCreating(builder);
        }
    }
}
