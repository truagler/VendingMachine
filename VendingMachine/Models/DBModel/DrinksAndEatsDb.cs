using System;

namespace WebApplication1.Models.DBModel
{
	public class DrinksAndEatsDb
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Int32 Price { get; set; }
		public Int32 CoinBase { get; set; }
		public String Img { get; set; }
		public Boolean IsRemoved { get; set; }
	}
}