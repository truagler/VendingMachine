using System;
using System.Collections.Generic;
using VendingMachine.Models.Domain;
using VendingMachine.Models.ViewModel;
using WebApplication1.Models.Enum;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.Code
{
	public class DrinkAndEatCode
	{
		private readonly ServiceInterface _serviceInterface;

		public DrinkAndEatCode(ServiceInterface serviceInterface)
		{
			_serviceInterface = serviceInterface;
		}

		public void AddProduct(String productName, Int32 price, String img)
		{
			_serviceInterface.AddDrinkOrEat(productName, price, img);
		}

		public void EditProduct(Int32 id, String productName, Int32 price, String img)
		{
			_serviceInterface.EditProduct(id, productName, price, img);
		}

		public void RemoveProduct(Int32 id)
		{
			_serviceInterface.RemoveProduct(id);
		}

		public DrinkAndCodeViewModel GetProduct(Int32 id)
		{
			DrinksAndEats domain = new DrinksAndEats() { Name = "Пепси", Price = 12, CoinBase = 20};//_serviceInterface.GetDrinkOrEat(id);
			
			DrinkAndCodeViewModel model = new DrinkAndCodeViewModel(){Product = domain};

			return model;
		}

		public DrinkAndCodeViewModel GetProducts()
		{
			List<DrinksAndEats> domain = new List<DrinksAndEats>(); //_serviceInterface.GetProducts();

			DrinksAndEats asd = new DrinksAndEats() {Id = 1, Name = "Пепси", Price = 123, Img ="asdasdasdasd" };
			
			domain.Add(asd);
			
			DrinkAndCodeViewModel viewModelList = new DrinkAndCodeViewModel(){Products = domain};
			
			return viewModelList;
		}

		public void ClickCoin(Int32 id, Coin coin)
		{
			_serviceInterface.ClickCoin(id, coin);
		}

		public void BuyProduct(Int32 id)
		{
			_serviceInterface.BuyProduct(id);
		}
	}
}