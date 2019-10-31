using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    static class ModelBuilderExtensions
    {
        public static void CreateMap(this ModelBuilder modelBuilder, params string[] names)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName().ToLower());
                foreach (var property in entityType.GetProperties())
                {
                    var propertyName = property.Name.ToLower();
                    var entityName = "";
                    property.SetColumnName(propertyName);

                    if (names.Contains(property.Name)) 
                        entityName = entityType.ClrType.Name.ToLower();
                       
                    property.SetColumnName(entityName + propertyName);
                }
            }
        }
    }
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(m => m.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(m => m.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(m => m.Description).HasColumnName("description");

            // Product
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(m => m.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(m => m.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(m => m.ProductName).HasColumnName("productname"); //redundant, but required by test.
            modelBuilder.Entity<Product>().Property(m => m.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(m => m.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(m => m.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>().Ignore(m => m.Category); // how to implement this?
            modelBuilder.Entity<Product>().Ignore(m => m.CategoryName); // redundant, but required by test

            // Order
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(m => m.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(m => m.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(m => m.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(m => m.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(m => m.ShipCity).HasColumnName("shipcity");
            modelBuilder.Entity<Order>().Ignore(m => m.OrderDetails); // how to implement this?
            
            // OrderDetails
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails").HasNoKey();
            modelBuilder.Entity<OrderDetails>().Property(m => m.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().Ignore(m => m.Order);
            modelBuilder.Entity<OrderDetails>().Ignore(m => m.Product);
        }
    }
}