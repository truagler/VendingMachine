using System;

namespace Machine.Models.DBmodel
{
	public class OrderDB
	{
		public Int32 Id { get; set; }
		public Int32 ProductId { get; set; }
		public DateTime CreatedDateTime { get; set; }

		public OrderDB() { }

		public OrderDB(Int32 id, Int32 productId, DateTime createdDateTime)
		{
			Id = id;
			ProductId = productId;
			CreatedDateTime = createdDateTime;
		}
	}
}