using System.Collections.Generic;
using Models;

namespace Services
{
	public interface IOrderService
	{
		Order GetOrder(int orderId);
		void SaveDetail(OrderDetail detail);
		List<Order> GetOrders();
	}
}