using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignement4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Assignment4
{
    public class DataService
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

        public bool UpdateCategory(int idIn, string inName, string inDescription)
        {
            return true;
        }

        public Product GetProduct(int inId)
        {
            return new Product();
        }
        
        public List<Product> GetProductByCategory(int inId)
        {
            return new List<Product>();
        }
        
        public List<Product> GetProductByName(string inName)
        {
            return new List<Product>();
        }

        public Order GetOrder(int inId)
        {
            return new Order();
        }
        
        public List<Order> GetOrders()
        {
            return new List<Order>();
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int inId)
        {
            return new List<OrderDetails>();
        }
        
        public List<OrderDetails> GetOrderDetailsByProductId(int inId)
        {
            return new List<OrderDetails>();
        }
    }
}
