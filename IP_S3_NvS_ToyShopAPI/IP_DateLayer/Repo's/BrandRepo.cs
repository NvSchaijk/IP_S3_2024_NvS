using System;
using Azure.Core;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.DTOs;
using IP_Models.Models;
using Microsoft.EntityFrameworkCore;

namespace IP_DateLayer.Repos
{
    public class BrandRepo : IBrandRepo
    {
        private readonly ToyShopAPIDBContext _dbContext;

        public BrandRepo(ToyShopAPIDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> CreateBrand(BrandDTO request)
        {
            try
            {
                await _dbContext.Brandset.AddAsync(request);
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

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                BrandDTO? original = await GetBrandById(id);

                if (original == null)
                {
                    return false;
                }

                _dbContext.Brandset.Remove(original);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BrandDTO?> GetBrandById(int id)
        {
            try
            {
                return await _dbContext.Brandset.FindAsync(id);
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<BrandDTO>> GetBrands()
        {
            try
            {
                return await _dbContext.Brandset.ToListAsync();
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<bool> UpdateBrand(BrandDTO request)
        {
            try
            {
                BrandDTO? original = await GetBrandById(request.BrandID);

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