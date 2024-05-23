using System;
using IP_Models.DTOs;

namespace IP_Contract_Business_DataLayer.interfaces
{
	public interface ICategory_ItemRepo
	{
        Task<IEnumerable<Category_ItemDTO>> GetCategory_Items();

        Task<Category_ItemDTO?> GetCategory_ItemById(int id);

        Task<bool> CreateCategory_Item(Category_ItemDTO request);

        Task<bool> UpdateCategory_Item(Category_ItemDTO request);

        Task<bool> DeleteCategory_Item(int id);
    }
}

