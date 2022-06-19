using System.Collections.Generic;
using System.Linq;
using Machine.Models.Blank;
using Machine.Models.DBmodel;
using Machine.Models.Domain;
using Machine.Models.ViewModel;

namespace Machine.Converter.ConverterCoin
{
	public class Converter
	{
		public CoinDB ToDb(Coin product)
		{
			return  new CoinDB(product.Id, product.CoinCategory, product.MaxCoinCount, product.NowCoinCount);
		}
		
		public List<CoinDB> ToDbs(List<Coin> products)
		{
			return  products.Select(ToDb).ToList();
		}
		
		public Coin ToDomain(CoinDB product)
		{
			return  new Coin(product.Id, product.CoinCategory, product.MaxCoinCount, product.NowCoinCount);
		}
		
		public Coin ToDomain(CoinBlank product)
		{
			return  new Coin(product.Id, product.CoinCategory, product.MaxCoinCount, product.NowCoinCount);
		}
		
		public List<Coin> ToDomains(List<CoinDB> products)
		{
			return  products.Select(ToDomain).ToList();
		}
		
		public CoinView ToView(Coin product)
		{
			return new CoinView(product.Id, product.CoinCategory, product.MaxCoinCount, product.NowCoinCount);
		}

		public List<CoinView> ToViews(List<Coin> products)
		{
			return products.Select(ToView).ToList();
		}
	}
}