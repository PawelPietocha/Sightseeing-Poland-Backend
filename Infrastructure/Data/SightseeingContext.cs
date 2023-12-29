using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SightseeingContext : DbContext
    {
        public SightseeingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Mountain> Mountains { get; set; }
    }
}