using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Domain;

namespace Machine.Service.Interface
{
	public interface IOrderService
	{
		Task AddOperator(Order order);
		Task<List<Order>> GetOrderHistory();
	}
}