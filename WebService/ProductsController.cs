using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using Assignment4;


namespace WebService
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {

        IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{productid}")]
        public ActionResult<Product> GetProduct(int inId)
        {
            var product = _dataService.GetProduct(inId);

            if (product == null) return NotFound();
            
            return Ok(product);
        }
        /*
        [HttpGet("{categoryId}")]
        public ActionResult<IEnumerable<Product>> GetProductByCategory(int inId)
        {
            var products = _dataService.GetProductByCategory(inId);

            if (products.Count == 0) return NotFound(products);

            return Ok(products);
        }
        
        [HttpGet("{productName}")]
        public ActionResult<IEnumerable<Product>> GetProductByName(string inName)
        {
            var products = _dataService.GetProductByName(inName);

            if (products.Count == 0) return NotFound(products);

            return Ok(products);
        }
        */
    }
}