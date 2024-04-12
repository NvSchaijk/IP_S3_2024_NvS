using System;
using IP_Models.DTOs;
using IP_Models.Models;

namespace IP_Contract_Business_DataLayer.interfaces
{
	public interface IBrandRepo
	{
        Task<IEnumerable<BrandDTO>> GetBrands();

        Task<BrandDTO?> GetBrandById(int id);

        Task<bool> CreateBrand(BrandDTO request);

        Task<bool> UpdateBrand(BrandDTO request);

        Task<bool> DeleteBrand(int id);
    }
}