using System;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;

namespace IP_Business.Components
{
    public class ItemComponent : IItemComponent
    {
        public Task<bool> AddItemToCategory(Category_Item category_item)
        {
            throw new NotImplementedException();
        }

        public Task<Item?> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemFromCategory(int relationid)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> IItemComponent.CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> IItemComponent.DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Item>> IItemComponent.UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}

