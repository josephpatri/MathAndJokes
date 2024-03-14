using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            // We do this for clean information
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Joke> jokes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            foreach (var joke in ChangeTracker.Entries<BaseEntity>())
            {
                switch (joke.State)
                {
                    case EntityState.Modified:
                        joke.Entity.Modified = DateTime.UtcNow;
                        joke.Entity.ModifiedBy = "Jokes Owner";
                        break;
                    case EntityState.Added:
                        joke.Entity.Modified = DateTime.UtcNow;
                        joke.Entity.Created = DateTime.UtcNow;
                        joke.Entity.CreatedBy = "Jokes Owner";
                        joke.Entity.ModifiedBy = "Jokes Owner";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellation);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}