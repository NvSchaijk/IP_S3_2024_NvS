using System;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.Models;
using IP_Models.DTOs;

namespace IP_Business
{
    public class BrandComponent : IBrandComponent
    {
        private readonly IBrandRepo _repo;

        public BrandComponent(IBrandRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Brand>> CreateBrand(Brand brand)
        {
            BrandDTO request = new BrandDTO
            {
                BrandName = brand.BrandName,
                BrandDescription = brand.BrandDescription
            };
            if( await _repo.CreateBrand(request) == true)
            {
                return await GetBrands();
            }
            return null;
        }

        public async Task<IEnumerable<Brand>> DeleteBrand(int id)
        {
           if( await _repo.DeleteBrand(id) == true)
            {
                return await GetBrands();
            }
            return null;
        }

        public async Task<Brand?> GetBrandById(int id)
        {
            var b = await _repo.GetBrandById(id);
            if (b != null)
            {
                Brand brand = new Brand
                {
                    BrandID = b.BrandID,
                    BrandName = b.BrandName,
                    BrandDescription = b.BrandDescription
                };

                return brand;
            }
            return null;
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            List<Brand> brandslist = new List<Brand>();

            foreach (var b in await _repo.GetBrands())
            {
                Brand brand = new Brand
                {
                    BrandID = b.BrandID,
                    BrandName = b.BrandName,
                    BrandDescription = b.BrandDescription
                };
                brandslist.Add(brand);
            }
            IEnumerable<Brand> brands = brandslist;

            return brands;
        }

        public async Task<IEnumerable<Brand>> UpdateBrand(Brand brand)
        {
            BrandDTO request = new BrandDTO
            {
                BrandID = brand.BrandID,
                BrandName = brand.BrandName,
                BrandDescription = brand.BrandDescription
            };

            if(await _repo.UpdateBrand(request) == true)
            {
                return await GetBrands();
            }
            return null;
        }
    }
}