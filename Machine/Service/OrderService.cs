using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Models.Domain;
using Machine.Repository.Interface;
using Machine.Service.Interface;
using Machine.Tools;

namespace Machine.Service
{
	public class OrderService: IOrderService
	{
		private IOrderRepository _orderRepository;

		private Converter.ConverterOrder.Converter _converter = new Converter.ConverterOrder.Converter();
		
		public OrderService(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task AddOperator(Order order)
		{
			order.Id = ID.NewID();
			order.CreatedDateTime = DateTime.Now;
			await _orderRepository.AddOrder(_converter.ToDb(order));
		}

		public Task<List<Order>> GetOrderHistory()
		{
			return Task.FromResult(_converter.ToDomains(_orderRepository.GetOrdersHistory().Result));
		}
	}
}