using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            optionsBuilder.UseNpgsql("host=localhost;db=northwind;uid=postgres;pwd=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category
            modelBuilder.Entity<Category>().ToTable("categories").HasNoKey();
            modelBuilder.Entity<Category>().Property(m => m.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(m => m.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(m => m.Description).HasColumnName("description");

            // Product
            modelBuilder.Entity<Product>().ToTable("products").HasNoKey();
            modelBuilder.Entity<Product>().Property(m => m.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(m => m.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(m => m.ProductName).HasColumnName("productname"); //twice for some reason....
            modelBuilder.Entity<Product>().Property(m => m.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(m => m.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(m => m.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>().Ignore(m => m.Category);
            // what about Category?
            
            // Order
            modelBuilder.Entity<Order>().ToTable("order").HasNoKey();
            modelBuilder.Entity<Order>().Property(m => m.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(m => m.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(m => m.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(m => m.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(m => m.ShipCity).HasColumnName("shipcity");
            // what about OrderDetails??
            
            // OrderDetails
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails").HasNoKey();
            modelBuilder.Entity<OrderDetails>().Property(m => m.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().Ignore(m => m.Order);
            modelBuilder.Entity<OrderDetails>().Ignore(m => m.Product);
            // what about Order and Product???
        }
    }
}