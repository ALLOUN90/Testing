using Microsoft.EntityFrameworkCore;
using Testing.Models;

namespace Testing.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DesplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DesplayOrder = 2 },
                new Category { Id = 3, Name = "History", DesplayOrder = 3 }
                );

            
        }
    }
}
