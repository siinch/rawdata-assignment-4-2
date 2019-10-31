using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Assignment4
{
    public class DataService : IDataService
    {
     
        
        public List<Category> GetCategories()
        {   
            using var db = new NorthwindContext();
            return db.Categories.ToList();
        }

        public Category GetCategory(int idIn)
        {   
            using var db = new NorthwindContext();
            return db.Categories
                .Where(x => x.Id == idIn)
                .Select(x => x).ToList().FirstOr(null);
        }
        
        public Category CreateCategory(string inName, string inDescription)
        {
            using var db = new NorthwindContext();
            if (!db.Categories.Select(x => x.Name).Contains(inName))
            {
                var existingIds = db.Categories.Select(x => x.Id).ToList();
                var newid = 1;
            
                while (existingIds.Contains(newid))
                {
                    newid++;
                }

                Category newCategory = new Category();
                newCategory.Id = newid;
                newCategory.Name = inName;
                newCategory.Description = inDescription;

                db.Categories.Add(newCategory);
                db.SaveChanges();
                
                return newCategory;   
            }
            else
            {
                return null;
            }
        }
        
        public bool DeleteCategory(int inId)
        {
            using var db = new NorthwindContext();
            if (db.Categories.Select(x => x.Id).Contains(inId))
            {
                db.Categories.Remove(db.Categories.Where(x => x.Id == inId).Select(x => x).ToList().First());
                db.SaveChanges();
                return true;
            }
            else 
                return false;
        }

        public bool UpdateCategory(int inId, string inName, string inDescription)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(inId);
            if (category != null)
            {
                category.Name = inName;
                category.Description = inDescription;
                db.SaveChanges();
                return true;
            }
            else 
                return false;
        }

        public Product GetProduct(int inId)
        {
            using var db = new NorthwindContext();
            var product = db.Products.Find(inId);
            if (product != null)
            {
                product.Category = db.Categories.Find(product.CategoryId);
                product.CategoryName = db.Categories.Find(product.CategoryId).Name;
            }
            return product;
        }
        
        public List<Product> GetProductByCategory(int inId)
        {
            using var db = new NorthwindContext();
            var products = db.Products.Where(x => x.CategoryId == inId).Select(x => x).ToList();
            foreach (var product in products)
            {
                product.Category = db.Categories.Find(product.CategoryId);
                product.CategoryName = db.Categories.Find(product.CategoryId).Name;
            }
            return products;
        }
        
        public List<Product> GetProductByName(string inName)
        {
            using var db = new NorthwindContext();
            var products = db.Products.Where(x => x.Name.Contains(inName)).Select(x => x).ToList();
            foreach (var product in products)
            {
                product.Category = db.Categories.Find(product.CategoryId);
                product.CategoryName = db.Categories.Find(product.CategoryId).Name;
            }
            return products;
        }

        public Order GetOrder(int inId)
        {
            using var db = new NorthwindContext();
            var order = db.Orders.Find(inId);
            order.OrderDetails = db.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => x).ToList();
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.Order = order;
                orderDetail.Product = GetProduct(orderDetail.ProductId);
            }
            return order;
        }
        
        public List<Order> GetOrders()
        {
            using var db = new NorthwindContext();
            var orders = db.Orders.ToList();
            foreach (var order in orders)
            {
                order.OrderDetails = db.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => x).ToList();
                foreach (var orderDetail in order.OrderDetails)
                {
                    orderDetail.Order = order;
                    orderDetail.Product = GetProduct(orderDetail.ProductId);
                }
            }
            return orders;
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int inId)
        {
            using var db = new NorthwindContext();
            var order = db.Orders.Find(inId);
            order.OrderDetails = db.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => x).ToList();
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.Order = order;
                orderDetail.Product = GetProduct(orderDetail.ProductId);
            }
            return order.OrderDetails;
        }
        
        public List<OrderDetails> GetOrderDetailsByProductId(int inId)
        {
            using var db = new NorthwindContext();
            var orderDetails = db.OrderDetails.Where(x => x.ProductId == inId).Select(x => x).ToList();
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.Order = GetOrder(orderDetail.OrderId);
                orderDetail.Product = GetProduct(orderDetail.ProductId);
            }
            return orderDetails;
        }
    }
}
