using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignment4;


namespace WebService
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {

        IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories =  _dataService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<Category> GetCategory(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            _dataService.CreateCategory(category.Name, category.Description);

            return Ok(category);
        }
        
        [HttpPut("{categoryId}")]
        public ActionResult UpdateCategory(int inId, string inName, string inDescription)
        {
            if (!_dataService.UpdateCategory(inId, inName, inDescription))
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(int categoryId)
        {
            if (!_dataService.DeleteCategory(categoryId))
                return NotFound();
            return NoContent();
        }


    }
}