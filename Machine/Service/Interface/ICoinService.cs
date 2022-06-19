using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Domain;

namespace Machine.Service.Interface
{
	public interface ICoinService
	{
		Task AddCoin(Coin coin);
		Task UpdateMaxCoin(Int32 coinId, Int32 maxCoinCount);
		Task UpdateNowCoin(Int32 coinId);
		Task<Coin> GetCoin(Int32 coinId);
		Task<List<Coin>> GetCoins();
	}
}