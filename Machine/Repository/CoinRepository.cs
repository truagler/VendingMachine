using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Machine.Models;
using Machine.Models.DBmodel;
using Machine.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Machine.Repository
{
	public class CoinRepository: ICoinRepository
	{
		private MachineDbContext _db;

		public CoinRepository(MachineDbContext db)
		{
			_db = db;
		}

		public async Task AddCoin(CoinDB coinDb)
		{
			await _db.Coin.AddAsync(coinDb);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateMaxCoin(Int32 coinId, Int32 maxCoinCount)
		{
			Task<CoinDB> coin = _db.Coin.FirstOrDefaultAsync(co => co.Id == coinId);

			if (coin != null)
			{
				coin.Result.MaxCoinCount = maxCoinCount;
			}

			await _db.SaveChangesAsync();
		}

		public async Task UpdateNowCoin(Int32 coinId, Int32 nowCoinCount)
		{
			Task<CoinDB> coin = _db.Coin.FirstOrDefaultAsync(co => co.Id == coinId);

			if (coin != null)
			{
				coin.Result.NowCoinCount = nowCoinCount;
			}

			await _db.SaveChangesAsync();
		}

		public async Task<List<CoinDB>> GetCoins()
		{
			return await _db.Coin.ToListAsync();
		}

		public async Task<CoinDB> GetCoin(Int32 coinId)
		{
			return await _db.Coin.FirstOrDefaultAsync(co => co.Id == coinId);
		}
	}
}