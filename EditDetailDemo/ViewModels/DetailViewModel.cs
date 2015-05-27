using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Models;
using Services;

namespace LoginInWpf.ViewModels
{
	public class DetailViewModel : ViewModelBase
	{
		public DetailViewModel(OrderDetail detail)
		{
			Detail = detail;
			_service = new OrderService();
		}

		public OrderDetail Detail { get; set; }

		private RelayCommand _SaveCommand;
		private OrderService _service;

		/// <summary>
		/// Gets the SaveCommand.
		/// </summary>
		public RelayCommand SaveCommand
		{
			get
			{
				return _SaveCommand
						?? (_SaveCommand = new RelayCommand(
						() =>
						{
							if (!SaveCommand.CanExecute(null))
							{
								_service.SaveDetail(Detail);
								return;
							}


						},
						() => Detail.IsDirty));
			}
		}
	}
}