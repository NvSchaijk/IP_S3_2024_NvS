using System;
using IP_Contract_ToyShopAPI_Business.interfaces;
using IP_Models.Models;

namespace IP_Business
{
    public class TestComponent : ITestComponent
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

