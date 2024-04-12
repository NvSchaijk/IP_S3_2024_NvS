using System;
using IP_Models.Models;

namespace IP_Contract_ToyShopAPI_Business.interfaces
{
	public interface IBrandComponent
	{
        Task<IEnumerable<Brand>> GetBrands();

        Task<Brand?> GetBrandById(int id);

        Task<IEnumerable<Brand>> CreateBrand(Brand brand);

        Task<IEnumerable<Brand>> UpdateBrand(Brand brand);

        Task<IEnumerable<Brand>> DeleteBrand(int id);
    }
}