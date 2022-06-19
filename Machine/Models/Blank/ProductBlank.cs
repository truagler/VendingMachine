using System;
using Machine.Models.Enum;

namespace Machine.Models.Blank
{
	public class ProductBlank
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Int32 CountProduct { get; set; }
		public Int32 Price { get; set; }
		public String Description { get; set; }
		public ProductCategory Category { get; set; }
		public Boolean IsRemoved { get; set; }
	}
}