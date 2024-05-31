using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IP_S3_NvS_ToyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashBoardController : ControllerBase
    {
        private readonly IItemComponent _ItemComponent;
        private readonly ILogger<DashBoardController> _Logger;

        public DashBoardController(IItemComponent itemComponent, ILogger<DashBoardController> logger)
        {
            _ItemComponent = itemComponent;
            _Logger = logger;
        }
        [HttpGet("BestSelling")]
        public async Task<ActionResult<IEnumerable<Item>>> GetBestSelling()
        {
            IEnumerable<Item> items = await _ItemComponent.GetBestSelling();
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("WorstSelling")]
        public async Task<ActionResult<IEnumerable<Item>>> GetWorstSelling()
        {
            IEnumerable<Item> items = await _ItemComponent.GetWorstSelling();
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("BestProfit")]
        public async Task<ActionResult<IEnumerable<ItemProfit>>> GetBestProfit()
        {
            IEnumerable<ItemProfit> items = await _ItemComponent.GetBestProfit();
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("WorstProfit")]
        public async Task<ActionResult<IEnumerable<ItemProfit>>> GetWorstProfit()
        {
            IEnumerable<ItemProfit> items = await _ItemComponent.GetWorstProfit();
            if (items != null)
            {
                return Ok(items);
            }
            return BadRequest("data could not be found");
        }
    }
}

