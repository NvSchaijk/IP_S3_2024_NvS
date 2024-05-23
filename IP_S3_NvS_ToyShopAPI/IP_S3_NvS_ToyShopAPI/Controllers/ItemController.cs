using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Business;
using IP_Business.Components;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace IP_S3_NvS_ToyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemComponent _ItemComponent;
        private readonly ILogger<ItemController> _Logger;

        public ItemController(IItemComponent itemComponent, ILogger<ItemController> logger)
        {
            _ItemComponent = itemComponent;
            _Logger = logger;
        }

        [HttpGet("GetItems")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            IEnumerable<Item> items = await _ItemComponent.GetItems();
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item?>> GetItemById(int id)
        {
            var item = await _ItemComponent.GetItemById(id);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest("data could not be found");

        }

        [HttpGet("Categories/{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetItem_CategoriesById(int id)
        {
            var categories = await _ItemComponent.GetCategoriesByItemId(id);
            if (categories != null)
            {
                return Ok(categories);
            }
            return Ok("items have no category or they are not found");

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Item>>> CreateItem(Item item)
        {
            IEnumerable<Item> items = await _ItemComponent.CreateItem(item);
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("something went wrong adding the category");
        }
        [HttpPatch]
        public async Task<ActionResult<IEnumerable<Item>>> UpdateItem(Item item)
        {
            IEnumerable<Item> items = await _ItemComponent.UpdateItem(item);
            if (items != null)
            {
                return Ok(item);
            }
            return BadRequest("something went wrong updating the category");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Item>>> DeleteItem(int id)
        {
            IEnumerable<Item> items = await _ItemComponent.DeleteItem(id);
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("something went wrong updating the category");
        }
    }
}
