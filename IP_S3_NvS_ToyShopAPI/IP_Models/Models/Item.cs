using System;
namespace IP_Models.Models
{
	public class Item
	{
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public int ItemQuantitySold { get; set; }
        public int BrandID { get; set; }
    }
}