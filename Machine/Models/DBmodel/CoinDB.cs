using System;
using Machine.Models.Enum;

namespace Machine.Models.DBmodel
{
	public class CoinDB
	{
		public Int32 Id { get; set; }
		public CoinCategory CoinCategory { get; set; }
		public Int32 MaxCoinCount { get; set; }
		public Int32 NowCoinCount { get; set; }

		public CoinDB() { }

		public CoinDB(Int32 id, CoinCategory coinCategory, Int32 maxCoinCount, Int32 nowCoinCount)
		{
			Id = id;
			CoinCategory = coinCategory;
			MaxCoinCount = maxCoinCount;
			NowCoinCount = nowCoinCount;
		}
	}
}