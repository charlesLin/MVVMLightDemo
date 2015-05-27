using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Design
{
	public class DesignOrderService : IOrderService
	{
		public Order GetOrder(int orderId)
		{
			throw new NotImplementedException();
		}

		public void SaveDetail(OrderDetail detail)
		{
			throw new NotImplementedException();
		}

		public List<Order> GetOrders()
		{
			var q = from i in Enumerable.Range(1, 5)
				select new Order()
				{
					Id = i,
					CustomerName = "Cust " + i.ToString(),
					Details = (from d in Enumerable.Range(1, 3)
						select new OrderDetail()
						{
							Id = d,
							ProductName = "Product " + i.ToString(),
							Amount = i*10,
							Quantity = i
						}).ToList()
				};
			return q.ToList();
		}
	}
}
