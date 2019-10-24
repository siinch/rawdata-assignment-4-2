using Assignement4;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("caregories");
            modelBuilder.Entity<Category>().Property(m => m.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(m => m.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(m => m.Description).HasColumnName("description");

        }
    }
}