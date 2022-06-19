using System;

namespace Machine.Models.ViewModel
{
	public class OrderView
	{
		public Int32 Id { get; set; }
		public Int32 ProductId { get; set; }
		public DateTime CreatedDateTime { get; set; }

		public OrderView() { }

		public OrderView(Int32 id, Int32 productId, DateTime createdDateTime)
		{
			Id = id;
			ProductId = productId;
			CreatedDateTime = createdDateTime;
		}
	}
}