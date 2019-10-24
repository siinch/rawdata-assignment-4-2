using Assignement4;

namespace Assignment4
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public  string CategoryName { get; set; }
        public double UnitPrice { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
    }
}