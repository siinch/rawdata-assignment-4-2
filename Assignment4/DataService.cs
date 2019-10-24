using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignement4;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class DataService
    {
     
        
        public List<Category> GetCategories()
        {   
            return new List<Category>();
        }

        public Category GetCategory(int idIn)
        {   
            return new Category();
        }
        
        public Category CreateCategory(string inName, string inDescription)
        {   
            return new Category();
        }
        
        public bool DeleteCategory(int inId)
        {
            return true;
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
