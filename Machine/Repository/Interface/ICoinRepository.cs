using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.DBmodel;

namespace Machine.Repository.Interface
{
	public interface ICoinRepository
	{
		Task AddCoin(CoinDB coinDb);
		Task UpdateMaxCoin(Int32 coinId, Int32 maxCoinCount);
		Task UpdateNowCoin(Int32 coinId, Int32 nowCoinCount);
		Task<List<CoinDB>> GetCoins();
		Task<CoinDB> GetCoin(Int32 coinId);
	}
}