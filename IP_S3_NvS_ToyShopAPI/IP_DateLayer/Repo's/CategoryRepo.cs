using System;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace IP_DateLayer.Repos
{
	public class CategoryRepo : ICategoryRepo
	{
		private readonly ToyShopAPIDBContext _dbContext;

		public CategoryRepo(ToyShopAPIDBContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<bool> CreateCategory(CategoryDTO request)
        {
            try
            {
                await _dbContext.Categoryset.AddAsync(request);
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

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                CategoryDTO? original = await GetCategoryById(id);

                if (original == null)
                {
                    return false;
                }

                _dbContext.Categoryset.Remove(original);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CategoryDTO?> GetCategoryById(int id)
        {
            try
            {
                return await _dbContext.Categoryset.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            try
            {
                return await _dbContext.Categoryset.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateCategory(CategoryDTO request)
        {
            try
            {
                CategoryDTO? original = await GetCategoryById(request.CategoryID);

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

