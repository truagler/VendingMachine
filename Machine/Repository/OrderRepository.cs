using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models;
using Machine.Models.DBmodel;
using Machine.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Machine.Repository
{
	public class OrderRepository: IOrderRepository
	{
		private MachineDbContext _db;

		public OrderRepository(MachineDbContext db)
		{
			_db = db;
		}

		public async Task AddOrder(OrderDB orderDb)
		{
			await _db.Order.AddAsync(orderDb);
			await _db.SaveChangesAsync();
		}

		public async Task<List<OrderDB>> GetOrdersHistory()
		{
			return await _db.Order.ToListAsync();
		}
	}
}