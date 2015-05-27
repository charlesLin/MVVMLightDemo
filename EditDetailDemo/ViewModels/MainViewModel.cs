using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Models;
using Services;
using Services.Design;

namespace LoginInWpf.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private readonly IOrderService _orderService;

		public MainViewModel()
		{
			if (IsInDesignMode)
				_orderService = new DesignOrderService();
			else
				_orderService = new OrderService();
			Orders = _orderService.GetOrders();
			foreach (var order in _orders)
				foreach (var detail in order.Details)
					detail.IsDirty = false;
		}

		#region Orders
		/// <summary>
		/// The <see cref="Orders" /> property's name.
		/// </summary>
		public const string OrdersPropertyName = "Orders";

		private List<Order> _orders = null;

		/// <summary>
		/// Sets and gets the Orders property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public List<Order> Orders
		{
			get
			{
				return _orders;
			}

			set
			{
				if (_orders == value)
				{
					return;
				}

				_orders = value;
				RaisePropertyChanged(() => Orders);
				Set(() => Orders, ref _orders, value);
			}
		}

		#endregion

		/// <summary>
		/// The <see cref="SelectedOrder" /> property's name.
		/// </summary>
		public const string SelectedOrderPropertyName = "SelectedOrder";

		private Order _order = null;

		/// <summary>
		/// Sets and gets the SelectedOrder property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public Order SelectedOrder
		{
			get
			{
				return _order;
			}

			set
			{
				if (_order == value)
				{
					return;
				}

				_order = value;
				RaisePropertyChanged(() => SelectedOrder);
			}
		}


	}
}
