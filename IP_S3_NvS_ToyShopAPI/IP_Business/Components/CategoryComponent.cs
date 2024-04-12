using System;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.DTOs;
using IP_Models.Models;

namespace IP_Business.Components
{
	public class CategoryComponent : ICategoryComponent
	{
        private readonly ICategoryRepo _repo;
		public CategoryComponent(ICategoryRepo repo)
		{
            _repo = repo;
		}

        public async Task<IEnumerable<Category>> CreateCategory(Category category)
        {
            CategoryDTO request = new CategoryDTO
            {
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };
            if (await _repo.CreateCategory(request) == true)
            {
                return await GetCategories();
            }
            return null;
        }

        public async Task<IEnumerable<Category>> DeleteCategory(int id)
        {
            if (await _repo.DeleteCategory(id) == true)
            {
                return await GetCategories();
            }
            return null;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categorylist = new List<Category>();

            foreach (var c in await _repo.GetCategories())
            {
                Category category = new Category
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription
                };
                categorylist.Add(category);
            }
            IEnumerable<Category> categories = categorylist;

            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            var c = await _repo.GetCategoryById(id);
            if (c != null)
            {
                Category category = new Category
                {
                    CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription
                };

                return category;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> UpdateCategory(Category category)
        {
            CategoryDTO request = new CategoryDTO
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };

            if (await _repo.UpdateCategory(request) == true)
            {
                return await GetCategories();
            }
            return null;
        }
    }
}

