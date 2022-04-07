using System;
using WebApplication1.Models.DBModel;
using WebApplication1.Models.Enum;

namespace WebApplication1.Models.Interfaces
{
	public interface RepositoryInteface
	{
		void AddDrinksOrEats(String productName, Int32 price, String img);
		void EditProduct(Int32 id, String productName, Int32 price, String img);
		void RemoveProduct(Int32 id);
		DrinksAndEatsDb GetDrinkOrEat(Int32 id);
		DrinksAndEatsDb[] GetProducts();
		void ClickCoin(Int32 id, Coin coin);
		void BuyProduct(Int32 id);
	}
}