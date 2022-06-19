using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.DBmodel;

namespace Machine.Repository.Interface
{
	public interface IOrderRepository
	{
		Task AddOrder(OrderDB orderDb);
		Task<List<OrderDB>> GetOrdersHistory();
	}
}