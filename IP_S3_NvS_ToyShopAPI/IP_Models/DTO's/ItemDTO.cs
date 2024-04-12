using System;
namespace IP_Models.DTOs
{
	public class ItemDTO
    {
		public int ItemID { get; set; }

		public int BrandID { get; set; }

		public string ItemName { get; set; }

		public string ItemDescription { get; set; }

		public Decimal ItemPrice { get; set; }

		public int ItemQuantity { get; set; }

		public int ItemQuantitySold { get; set; }
	}
}