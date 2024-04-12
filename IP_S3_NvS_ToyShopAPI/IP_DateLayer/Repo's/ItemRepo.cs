using System;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IP_DateLayer.Repos
{
    public class ItemRepo : IItemRepo
    {
        private readonly ToyShopAPIDBContext _dbContext;

        public ItemRepo(ToyShopAPIDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CreateItem(ItemDTO request)
        {
            try
            {
                await _dbContext.Itemset.AddAsync(request);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteItem(int id)
        {
            try
            {
                ItemDTO? original = await GetItemById(id);

                if (original == null)
                {
                    return false;
                }

                _dbContext.Itemset.Remove(original);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ItemDTO?> GetItemById(int id)
        {
            return await _dbContext.Itemset.FindAsync(id);
        }

        public async Task<IEnumerable<ItemDTO>> GetItems()
        {
            return await _dbContext.Itemset.ToListAsync();
        }

        public async Task<bool> UpdateItem(ItemDTO request)
        {
            try
            {
                ItemDTO? original = await GetItemById(request.ItemID);

                if (original == null) return false;

                _dbContext.Entry(original).CurrentValues.SetValues(request);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

