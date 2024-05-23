using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IP_Business;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IP_S3_NvS_ToyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandComponent _BrandComponent;
        private readonly ILogger<BrandController> _Logger;

        public BrandController(IBrandComponent brandComponent, ILogger<BrandController> logger)
        {
            _BrandComponent = brandComponent;
            _Logger = logger;
        }

        [HttpGet(Name = "GetBrands")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            IEnumerable<Brand> brands = await _BrandComponent.GetBrands();
            if (brands != null)
            {
                return Ok(brands);
            }
            return BadRequest("data could not be found");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand?>> GetBrandById(int id)
        {
            var brand = await _BrandComponent.GetBrandById(id);
            if (brand != null)
            {
                return Ok(brand);
            }
            return BadRequest("contact not found");
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Brand>>> CreateBrand(Brand brand)
        {
            IEnumerable<Brand> brands = await _BrandComponent.CreateBrand(brand);
            if (brands != null)
            {
                return Ok(brands);
            }
            return BadRequest("something went wrong adding the brand");
        }
        [HttpPatch]
        public async Task<ActionResult<IEnumerable<Brand>>> UpdateBrand(Brand brand)
        {
            IEnumerable<Brand> brands = await _BrandComponent.UpdateBrand(brand);
            if (brands != null)
            {
                return Ok(brands);
            }
            return BadRequest("something went wrong updating the brand");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Brand>>> DeleteBrand(int id)
        {
            IEnumerable<Brand> brands = await _BrandComponent.DeleteBrand(id);
            if (brands != null)
            {
                return Ok(brands);
            }
            return BadRequest("something went wrong deleting the brand");
        }

    }
}

