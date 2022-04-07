using System;
using System.Collections.Generic;
using VendingMachine.Models.Domain;
using WebApplication1.Models.DBModel;
using WebApplication1.Models.Enum;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.Services
{
	public class DrinksOrEatsServices: ServiceInterface
	{
		private readonly RepositoryInteface _repository;
		
		public DrinksOrEatsServices(RepositoryInteface repository)
		{
			_repository = repository;
		}
		
		public void AddDrinkOrEat(String productName, Int32 price, String img)
		{
			_repository.AddDrinksOrEats(productName, price, img);
		}

		public void EditProduct(Int32 id, String productName, Int32 price, String img)
		{
			_repository.EditProduct(id, productName, price, img);
		}

		public void RemoveProduct(Int32 id)
		{
			_repository.RemoveProduct(id);
		}

		public DrinksAndEats GetDrinkOrEat(Int32 id)
		{
			DrinksAndEatsDb db = _repository.GetDrinkOrEat(id);

			DrinksAndEats domain = new DrinksAndEats(){Id = db.Id, Name = db.Name, Price = db.Price, Img = db.Img};

			return domain;
		}

		public List<DrinksAndEats> GetProducts()
		{
			DrinksAndEatsDb[] dbs = _repository.GetProducts();

			List<DrinksAndEats> domainList = new List<DrinksAndEats>();
			
			foreach (DrinksAndEatsDb db in dbs)
			{
				DrinksAndEats domain = new DrinksAndEats(){Id = db.Id, Name = db.Name, Price = db.Price, Img = db.Img};
				domainList.Add(domain);
			}

			return domainList;
		}

		public void ClickCoin(Int32 id, Coin coin)
		{
			_repository.ClickCoin(id, coin);
		}

		public void BuyProduct(Int32 id)
		{
			_repository.BuyProduct(id);
		}
	}
}