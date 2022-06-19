using System.Collections.Generic;
using System.Linq;
using Machine.Models.Blank;
using Machine.Models.DBmodel;
using Machine.Models.Domain;
using Machine.Models.ViewModel;

namespace Machine.Converter.ConverterOrder
{
	public class Converter
	{
		public OrderDB ToDb(Order product)
		{
			return  new OrderDB(product.Id, product.ProductId, product.CreatedDateTime);
		}
		
		public List<OrderDB> ToDbs(List<Order> products)
		{
			return  products.Select(ToDb).ToList();
		}
		
		public Order ToDomain(OrderDB product)
		{
			return  new Order(product.Id, product.ProductId, product.CreatedDateTime);
		}
		
		public Order ToDomain(OrderBlank product)
		{
			return  new Order(product.Id, product.ProductId, product.CreatedDateTime);
		}
		
		public List<Order> ToDomains(List<OrderDB> products)
		{
			return  products.Select(ToDomain).ToList();
		}
		
		public OrderView ToView(Order product)
		{
			return new OrderView(product.Id, product.ProductId, product.CreatedDateTime);
		}

		public List<OrderView> ToViews(List<Order> products)
		{
			return products.Select(ToView).ToList();
		}
	}
}