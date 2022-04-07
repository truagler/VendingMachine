using System;

namespace VendingMachine.Models.Domain
{
	public class DrinksAndEats
	{
		public Int32 Id { get; set; }
		public String Name { get; set; }
		public Int32 Price { get; set; }
		public String Img { get; set; }
		public Int32 CoinBase { get; set; }
	}
}