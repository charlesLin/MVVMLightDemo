using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
		public class DataContext : DbContext
		{
			public DataContext(): base("mvvm")
			{
				
			}

			public virtual DbSet<Order> Orders { get; set; }
			public virtual DbSet<OrderDetail> OrderDetails { get; set; }
		}
}
