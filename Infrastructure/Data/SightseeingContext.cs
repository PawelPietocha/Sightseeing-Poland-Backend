using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SightseeingContext : DbContext
    {
        public SightseeingContext(DbContextOptions<SightseeingContext> options) : base(options)
        {
        }

        public DbSet<Mountain> Mountains { get; set; }
        public DbSet<Voivodeship> Voivodeships { get; set; }
        public DbSet<MountainsRange> MountainsRanges { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}