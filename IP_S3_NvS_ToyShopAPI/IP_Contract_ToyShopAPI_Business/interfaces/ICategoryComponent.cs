using System;
using IP_Models.Models;

namespace IP_Contract_ToyShopAPI_Business.interfaces
{
	public interface ICategoryComponent
	{
        Task<IEnumerable<Category>> GetCategories();

        Task<Category?> GetCategoryById(int id);

        Task<IEnumerable<Category>> CreateCategory(Category category);

        Task<IEnumerable<Category>> UpdateCategory(Category category);

        Task<IEnumerable<Category>> DeleteCategory(int id);
    }
}

