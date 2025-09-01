using Microsoft.EntityFrameworkCore;
using MaterialApi.Models;

namespace MaterialApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }   // Table for Materials
    }
}
