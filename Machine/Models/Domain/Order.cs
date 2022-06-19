using System;

namespace Machine.Models.Domain
{
	public class Order
	{
		public Int32 Id { get; set; }
		public Int32 ProductId { get; set; }
		public DateTime CreatedDateTime { get; set; }

		public Order() { }

		public Order(Int32 id, Int32 productId, DateTime createdDateTime)
		{
			Id = id;
			ProductId = productId;
			CreatedDateTime = createdDateTime;
		}
	}
}