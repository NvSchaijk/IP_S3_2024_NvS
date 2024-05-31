using System;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;
using IP_Models.DTOs;
using IP_Contract_Business_DataLayer.interfaces;

namespace IP_Business.Components
{
    public class ItemComponent : IItemComponent
    {
        private readonly IItemRepo _repo;
        private readonly IBrandRepo _brandRepo;
        private readonly ICategory_ItemRepo _category_itemRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly CategoryComponent categorycomponent;
        public ItemComponent(IItemRepo repo, IBrandRepo brandRepo, ICategory_ItemRepo category_ItemRepo, ICategoryRepo categoryRepo)
        {
            _repo = repo;
            _brandRepo = brandRepo;
            _category_itemRepo = category_ItemRepo;
            _categoryRepo = categoryRepo;
        }

        public Task<bool> AddItemToCategory(Category_Item category_item)
        {
            throw new NotImplementedException();
        }


        public async Task<Item?> GetItemById(int id)
        {
            var i = await _repo.GetItemById(id);
            if (i != null)
            {
                Item Item = new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID

                };

                return Item;
            }
            return null;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            List<Item> Itemlist = new List<Item>();

            foreach (var i in await _repo.GetItems())
            {
                Item Item = new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID
                    
                };
                Itemlist.Add(Item);
            }
            IEnumerable<Item> Items = Itemlist;

            return Items;
        }

        public async Task<bool> RemoveItemFromCategory(int relationid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> CreateItem(Item item)
        {
            ItemDTO request = new ItemDTO
            {
                ItemID = item.ItemID,
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemPrice = item.ItemPrice,
                ItemQuantity = item.ItemQuantity,
                ItemQuantitySold = item.ItemQuantitySold,
                BrandID = item.BrandID
            };
            if (await _repo.CreateItem(request) == true)
            {
                return await GetItems();
            }
            return null;
        }

        public async Task<IEnumerable<Item>> DeleteItem(int id)
        {
            if(await _repo.DeleteItem(id) == true)
            {
                return await GetItems();
            }
            return null;
        }

        public async Task<IEnumerable<Item>> UpdateItem(Item item)
        {
            ItemDTO request = new ItemDTO
            {
                ItemID = item.ItemID,
                ItemName = item.ItemName,
                ItemDescription = item.ItemDescription,
                ItemPrice = item.ItemPrice,
                ItemQuantity = item.ItemQuantity,
                ItemQuantitySold = item.ItemQuantitySold,
                BrandID = item.BrandID
            };

            if (await _repo.UpdateItem(request) == true)
            {
                return await GetItems();
            }
            return null;
        }

        public async Task<IEnumerable<Category>> GetCategoriesByItemId(int id)
        {
            List<Category> categories = new List<Category>();
            var category_itemDTOs = await _category_itemRepo.GetCategory_Items();
            foreach (var ci in category_itemDTOs)
            {
                if (ci.ItemID == id)
                {
                    var category = await categorycomponent.GetCategoryById(ci.CategoryID);
                    categories.Add(category);
                }
            }


            return categories;

        }
        public async Task<IEnumerable<Item>> GetBestSelling()
        {
            List<Item> Itemlist = new List<Item>();
            foreach (var i in await _repo.GetItems())
            {
                Item Item = new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID

                };
                Itemlist.Add(Item);
            }
            return Itemlist.OrderByDescending(item => item.ItemQuantitySold)
                        .Take(5)
                        .ToList();
        }
        public async Task<IEnumerable<Item>> GetWorstSelling()
        {
            List<Item> Itemlist = new List<Item>();
            foreach (var i in await _repo.GetItems())
            {
                Item Item = new Item
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID

                };
                Itemlist.Add(Item);
            }
            return Itemlist.OrderBy(item => item.ItemQuantitySold)
                        .Take(5)
                        .ToList();
        }
        public async Task<IEnumerable<ItemProfit>> GetBestProfit()
        {
            List<ItemProfit> Itemlist = new List<ItemProfit>();
            foreach (var i in await _repo.GetItems())
            {
                ItemProfit Item = new ItemProfit
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID,
                    Totalprofit = i.ItemPrice * i.ItemQuantitySold

                };
                Itemlist.Add(Item);
            }
            return Itemlist.OrderByDescending(item => item.Totalprofit)
                        .Take(5)
                        .ToList();
        }
        public async Task<IEnumerable<ItemProfit>> GetWorstProfit()
        {
            List<ItemProfit> Itemlist = new List<ItemProfit>();
            foreach (var i in await _repo.GetItems())
            {
                ItemProfit Item = new ItemProfit
                {
                    ItemID = i.ItemID,
                    ItemName = i.ItemName,
                    ItemDescription = i.ItemDescription,
                    ItemPrice = i.ItemPrice,
                    ItemQuantity = i.ItemQuantity,
                    ItemQuantitySold = i.ItemQuantitySold,
                    BrandID = i.BrandID,
                    Totalprofit = i.ItemPrice * i.ItemQuantitySold

                };
                Itemlist.Add(Item);
            }
            return Itemlist.OrderBy(item => item.Totalprofit)
                        .Take(5)
                        .ToList();
        }
    }
}

