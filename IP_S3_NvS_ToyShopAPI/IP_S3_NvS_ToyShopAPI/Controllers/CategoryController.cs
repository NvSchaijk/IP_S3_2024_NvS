using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Business.Components;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IP_S3_NvS_ToyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryComponent _CategoryComponent;
        private readonly ILogger<CategoryController> _Logger;

        public CategoryController(ICategoryComponent categoryComponent, ILogger<CategoryController> logger)
        {
            _CategoryComponent = categoryComponent;
            _Logger = logger;
        }

        [HttpGet(Name = "GetCategory")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            IEnumerable<Category> category = await _CategoryComponent.GetCategories();
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category?>> GetCategoryById(int id)
        {
            var category = await _CategoryComponent.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest("contact not found");
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Category>>> CreateCategory(Category category)
        {
            IEnumerable<Category> categories = await _CategoryComponent.CreateCategory(category);
            if (categories != null)
            {
                return Ok(categories);
            }
            return BadRequest("something went wrong adding the category");
        }
        [HttpPatch]
        public async Task<ActionResult<IEnumerable<Category>>> UpdateBrand(Category category)
        {
            IEnumerable<Category> categories = await _CategoryComponent.UpdateCategory(category);
            if (categories != null)
            {
                return Ok(categories);
            }
            return BadRequest("something went wrong updating the category");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> DeleteCategory(int id)
        {
            IEnumerable<Category> categories = await _CategoryComponent.DeleteCategory(id);
            if (categories != null)
            {
                return Ok(categories);
            }
            return BadRequest("something went wrong updating the category");
        }

    }
}

