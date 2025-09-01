using Microsoft.EntityFrameworkCore;
using MaterialApi.Models;

namespace MaterialApi.Data
{
    public class MaterialContext : DbContext
    {
        public MaterialContext(DbContextOptions<MaterialContext> options) : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }
    }
}