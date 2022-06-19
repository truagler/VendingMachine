using System;
using Machine.Models.Enum;

namespace Machine.Models.Domain
{
	public class Product
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Int32 CountProduct { get; set; }
		public Int32 Price { get; set; }
		public String Description { get; set; }
		public ProductCategory Category { get; set; }
		public Boolean IsRemoved { get; set; }

		public Product() { }

		public Product(Int32 id, String name, Int32 countProduct, Int32 price, String description, ProductCategory category, Boolean isRemoved)
		{
			Id = id;
			Name = name;
			CountProduct = countProduct;
			Price = price;
			Description = description;
			Category = category;
			IsRemoved = isRemoved;
		}
	}
}