using System.Collections.Generic;
using System.Linq;

namespace Models
{
	public class Order
	{
		public int Id { get; set; }

		public string CustomerName { get; set; }

		public int Amount
		{
			get { return Details.Sum(x => x.Amount); }
		}

		public List<OrderDetail> Details { get; set; }

	}
}
