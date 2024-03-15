using System;
using IP_Contract_Business_DataLayer.interfaces;
using IP_Models.Models;

namespace IP_DateLayer.Repos
{
    public class TestRepo : ITestRepo
    {
        public Task<bool> CreateTestAsync(Test order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTestAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Test?> GetTestByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemFromTestAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTestAsync(Test test)
        {
            throw new NotImplementedException();
        }
    }
}

