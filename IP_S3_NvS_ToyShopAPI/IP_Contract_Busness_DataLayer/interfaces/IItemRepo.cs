﻿using System;
using IP_Models.DTOs;

namespace IP_Contract_Business_DataLayer.interfaces
{
	public interface IItemRepo
	{
        Task<IEnumerable<ItemDTO>> GetItems();

        Task<ItemDTO?> GetItemById(int id);

        Task<bool> CreateItem(ItemDTO order);

        Task<bool> UpdateItem(ItemDTO test);

        Task<bool> DeleteItem(int id);
    }
}

