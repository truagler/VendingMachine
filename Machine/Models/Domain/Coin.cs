using System;
using Machine.Models.Enum;

namespace Machine.Models.Domain
{
	public class Coin
	{
		public Int32 Id { get; set; }
		public CoinCategory CoinCategory { get; set; }
		public Int32 MaxCoinCount { get; set; }
		public Int32 NowCoinCount { get; set; }

		public Coin() { }

		public Coin(Int32 id, CoinCategory coinCategory, Int32 maxCoinCount, Int32 nowCoinCount)
		{
			Id = id;
			CoinCategory = coinCategory;
			MaxCoinCount = maxCoinCount;
			NowCoinCount = nowCoinCount;
		}
	}
}