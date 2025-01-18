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
        public DbSet<Atividade> Activitys { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>(u =>
                {
                    u.HasKey(x => x.Id);

                    u.HasMany(a => a.Atividades)
                             .WithOne(u => u.Client)
                             .HasForeignKey(u => u.IdUser)
                             .OnDelete(DeleteBehavior.Restrict);
                });

            builder
               .Entity<Project>(u =>
               {
                   u.HasKey(x => x.Id);

                   u.HasOne(u => u.User)                   
                            .WithMany(f => f.Projects)
                            .HasForeignKey(u => u.IdUser)                            
                            .OnDelete(DeleteBehavior.Restrict);

                            

               });

            builder
               .Entity<Atividade>(u =>
               {
                   u.HasKey(x => x.Id);

                   u.HasOne(u => u.ProjectName)
                   .WithMany(a => a.Atividades)
                   .HasForeignKey(a => a.IdProject)
                   .OnDelete(DeleteBehavior.Restrict);
               });

            base.OnModelCreating(builder);
        }
    }
}
