using Management.Data.Mapping;
using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
