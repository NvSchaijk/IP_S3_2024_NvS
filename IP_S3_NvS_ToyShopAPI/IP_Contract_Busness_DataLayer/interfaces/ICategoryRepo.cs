using System;
using IP_Models.DTOs;

namespace IP_Contract_Business_DataLayer.interfaces
{
	public interface ICategoryRepo
	{
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<CategoryDTO?> GetCategoryById(int id);

        Task<bool> CreateCategory(CategoryDTO request);

        Task<bool> UpdateCategory(CategoryDTO request);

        Task<bool> DeleteCategory(int id);
    }
}

