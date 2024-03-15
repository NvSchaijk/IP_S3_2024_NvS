using System;
using IP_Models.Models;

namespace IP_Contract_Business_DataLayer.interfaces
{
	public interface ITestRepo
	{
        Task<Test?> GetTestByIdAsync(int id);

        Task<bool> CreateTestAsync(Test order);

        Task<bool> UpdateTestAsync(Test test);

        Task<bool> RemoveItemFromTestAsync(int id);

        Task<bool> DeleteTestAsync(int id);
    }
}

