using Microsoft.EntityFrameworkCore;
using Schedulerer.Domain;

namespace Schedulerer.Infrastructure
{
    public class SchedulererDbContext : DbContext
    {
        public DbSet<Child> Children { get; set; }
        public DbSet<Educator> Educators { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public SchedulererDbContext(DbContextOptions<SchedulererDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}