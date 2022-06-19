using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.DBmodel;
using Machine.Models.Domain;
using Machine.Repository.Interface;
using Machine.Service.Interface;
using Machine.Tools;

namespace Machine.Service
{
	public class CoinService:ICoinService
	{
		private ICoinRepository _coinRepository;

		private Converter.ConverterCoin.Converter _converter = new Converter.ConverterCoin.Converter();

		public CoinService(ICoinRepository coinRepository)
		{
			_coinRepository = coinRepository;
		}

		public async Task AddCoin(Coin coin)
		{
			coin.Id = ID.NewID();
			await _coinRepository.AddCoin(_converter.ToDb(coin));
		}

		public async Task UpdateMaxCoin(Int32 coinId, Int32 maxCoinCount)
		{
			await _coinRepository.UpdateMaxCoin(coinId, maxCoinCount);
		}

		public async Task UpdateNowCoin(Int32 coinId)
		{
			Int32 nowCoinCount = GetCoin(coinId).Result.NowCoinCount - 1;
			await _coinRepository.UpdateNowCoin(coinId, nowCoinCount);
		}

		public Task<Coin> GetCoin(Int32 coinId)
		{
			return Task.FromResult(_converter.ToDomain(_coinRepository.GetCoin(coinId).Result));
		}
		
		public Task<List<Coin>> GetCoins()
		{
			return Task.FromResult(_converter.ToDomains(_coinRepository.GetCoins().Result));
		}
	}
}