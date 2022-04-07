using System;
using System.Data.Entity;
using System.Linq;
using VendingMachine.Models.Context;
using WebApplication1.Models.DBModel;
using WebApplication1.Models.Enum;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.Repository
{
	public class DrinksEatsRepository: RepositoryInteface
	{
		public void AddDrinksOrEats(String productName, Int32 price, String img)
		{
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				DrinksAndEatsDb product = new DrinksAndEatsDb(){Name = productName, Price = price, Img = img, CoinBase = 0, IsRemoved = false};
				
				db.Products.Add(product);
			}
		}

		public void EditProduct(Int32 id, String productName, Int32 price, String img)
		{
			DrinksAndEatsDb product = new DrinksAndEatsDb();
			
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				product = db.Products.FirstOrDefault(prod => prod.Id == id);
				if (product != null)
				{
					product.Name = productName;
					product.Price = price;
					product.Img = img;
				}
				db.SaveChanges();
			}
		}

		public void RemoveProduct(Int32 id)
		{
			DrinksAndEatsDb product = new DrinksAndEatsDb();
			
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				product = db.Products.FirstOrDefault(prod => prod.Id == id);
				if (product != null)
				{
					product.IsRemoved = true;
					db.SaveChanges();
				}
			}
		}
		
		public DrinksAndEatsDb GetDrinkOrEat(Int32 id)
		{
			DrinksAndEatsDb product = new DrinksAndEatsDb();
				
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				product = db.Products.FirstOrDefault(prod => prod.Id == id);
			}

			return product;
		}

		public DrinksAndEatsDb[] GetProducts()
		{
			DrinksAndEatsDb[] product = new DrinksAndEatsDb[]{};
				
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				product = db.Products.Where(prod => prod.IsRemoved == false).ToArray();
			}

			return product;
		}

		public void ClickCoin(Int32 id, Coin coin)
		{
			const Int32 one = 1;
			const Int32 two = 2;
			const Int32 five = 5;
			const Int32 ten = 10;
			
			if (coin == Coin.One)
			{
				DrinksAndEatsDb product = new DrinksAndEatsDb();
			
				using (DrinksAndEatContext db = new DrinksAndEatContext())
				{
					product = db.Products.FirstOrDefault(prod => prod.Id == id);
					if (product != null)
					{
						product.CoinBase = one + product.CoinBase;
						db.SaveChanges();
					}
				}
			}
			
			if (coin == Coin.Two)
			{
				DrinksAndEatsDb product = new DrinksAndEatsDb();
			
				using (DrinksAndEatContext db = new DrinksAndEatContext())
				{
					product = db.Products.FirstOrDefault(prod => prod.Id == id);
					if (product != null)
					{
						product.CoinBase = two + product.CoinBase;
						db.SaveChanges();
					}
				}
			}
			
			if (coin == Coin.Five)
			{
				DrinksAndEatsDb product = new DrinksAndEatsDb();
			
				using (DrinksAndEatContext db = new DrinksAndEatContext())
				{
					product = db.Products.FirstOrDefault(prod => prod.Id == id);
					if (product != null)
					{
						product.CoinBase = five + product.CoinBase;
						db.SaveChanges();
					}
				}
			}
			
			if (coin == Coin.Ten)
			{
				DrinksAndEatsDb product = new DrinksAndEatsDb();
			
				using (DrinksAndEatContext db = new DrinksAndEatContext())
				{
					product = db.Products.FirstOrDefault(prod => prod.Id == id);
					if (product != null)
					{
						product.CoinBase = ten + product.CoinBase;
						db.SaveChanges();
					}
				}
			}
		}

		public void BuyProduct(Int32 id)
		{
			DrinksAndEatsDb product = new DrinksAndEatsDb();
			
			using (DrinksAndEatContext db = new DrinksAndEatContext())
			{
				product = db.Products.FirstOrDefault(prod => prod.Id == id);
				if (product != null)
				{
					if (product.CoinBase >= product.Price)
					{
						product.CoinBase = 0;
					}
					db.SaveChanges();
				}
			}
		}
	}
}