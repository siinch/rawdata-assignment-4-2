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
        
        
    }
}