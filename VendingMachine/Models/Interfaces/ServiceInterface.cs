using System;
using System.Collections.Generic;
using VendingMachine.Models.Domain;
using WebApplication1.Models.Enum;

namespace WebApplication1.Models.Interfaces
{
	public interface ServiceInterface
	{
		void AddDrinkOrEat(String productName, Int32 price, String img);
		void EditProduct(Int32 id, String productName, Int32 price, String img);
		void RemoveProduct(Int32 id);
		DrinksAndEats GetDrinkOrEat(Int32 id);
		List<DrinksAndEats> GetProducts();
		void ClickCoin(Int32 id, Coin coin);
		void BuyProduct(Int32 id);
	}
}