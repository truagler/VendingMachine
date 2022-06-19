using System;
using Machine.Models.Enum;

namespace Machine.Models.Blank
{
	public class CoinBlank
	{
		public Int32 Id { get; set; }
		public CoinCategory CoinCategory { get; set; }
		public Int32 MaxCoinCount { get; set; }
		public Int32 NowCoinCount { get; set; }
	}
}