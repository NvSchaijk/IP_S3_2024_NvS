using System;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IP_DateLayer.Repos
{
	public class Category_ItemRepo : ICategory_ItemRepo
	{
        private readonly ToyShopAPIDBContext _dbContext;

        public Category_ItemRepo(ToyShopAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateCategory_Item(Category_ItemDTO request)
        {
            try
            {
                await _dbContext.Category_Itemset.AddAsync(request);
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

        public async Task<bool> DeleteCategory_Item(int id)
        {
            try
            {
                Category_ItemDTO? original = await GetCategory_ItemById(id);

                if (original == null)
                {
                    return false;
                }

                _dbContext.Category_Itemset.Remove(original);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Category_ItemDTO?> GetCategory_ItemById(int id)
        {
            return await _dbContext.Category_Itemset.FindAsync(id);
        }

        public async Task<IEnumerable<Category_ItemDTO>> GetCategory_Items()
        {
            return await _dbContext.Category_Itemset.ToListAsync();
        }

        public async Task<bool> UpdateCategory_Item(Category_ItemDTO request)
        {
            try
            {
                Category_ItemDTO? original = await GetCategory_ItemById(request.Category_ItemID);

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

