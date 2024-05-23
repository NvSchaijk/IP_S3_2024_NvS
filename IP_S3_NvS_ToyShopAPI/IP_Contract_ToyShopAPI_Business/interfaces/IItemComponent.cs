using System;
using IP_Models.Models;

namespace IP_Contract_ToyShopAPI_Business.interfaces
{
	public interface IItemComponent
	{
        Task<IEnumerable<Item>> GetItems();

        Task<Item?> GetItemById(int id);

        Task<IEnumerable<Item>> CreateItem(Item item);

        Task<IEnumerable<Item>> UpdateItem(Item item);

        Task<IEnumerable<Item>> DeleteItem(int id);

        Task<bool> AddItemToCategory(Category_Item category_item);

        Task<bool> RemoveItemFromCategory(int relationid);

        Task<IEnumerable<Category>> GetCategoriesByItemId(int id);
    }
}

