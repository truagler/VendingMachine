using System;
using System.Collections.Generic;
using VendingMachine.Models.Domain;

namespace VendingMachine.Models.ViewModel
{
	public class DrinkAndCodeViewModel
	{
		public List<DrinksAndEats> Products { get; set; }
		public DrinksAndEats Product { get; set; }
	}
}