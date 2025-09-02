using MaterialApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the precision for decimal properties
            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.GstPercent).HasColumnType("decimal(18, 2)");
            });
        }
    }
}

