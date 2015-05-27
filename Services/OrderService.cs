using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using System.Data.Entity;

namespace Services
{
	public class OrderService : IOrderService
	{
			private DataContext _db;

			public OrderService()
			{
				_db = new DataContext();
			}

			public Order GetOrder(int orderId)
			{
				return _db.Orders.Include(x => x.Details).FirstOrDefault(i => i.Id == orderId);
			}

			public void SaveDetail(OrderDetail detail)
			{
				_db.OrderDetails.Attach(detail);
				_db.Entry(detail).State = EntityState.Modified;
				_db.SaveChanges();
			}

			public List<Order> GetOrders()
			{
				return _db.Orders.Include(x => x.Details).ToList();
			}
		}
}
