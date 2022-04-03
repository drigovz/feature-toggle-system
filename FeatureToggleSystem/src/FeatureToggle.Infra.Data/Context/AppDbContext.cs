using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FeatureToggle.Domain.Entities;

namespace FeatureToggle.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<FeatureFlag> FeatureFlags { get; set; }
        public DbSet<FeatureGroup> FeatureGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FeatureFlag>()
                   .HasNoDiscriminator()
                   .ToContainer(nameof(FeatureFlag))
                   .HasPartitionKey(x => x.Id)
                   .HasKey(x => new { x.Id });

            builder.Entity<FeatureGroup>()
                   .HasNoDiscriminator()
                   .ToContainer(nameof(FeatureGroup))
                   .HasPartitionKey(x => x.Id)
                   .HasKey(x => new { x.Id });

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
