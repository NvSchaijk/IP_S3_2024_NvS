using System;
namespace IP_Models.Models
{
	public class Item
	{
        public int ItemID { get; set; }

        public Brand ItemBrand { get; set; }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        public Decimal ItemPrice { get; set; }

        public int ItemQuantity { get; set; }

        public int ItemQuantitySold { get; set; }
    }
}