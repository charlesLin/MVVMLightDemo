using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EventToCommandDemo
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel()
		{
			
		}

		/// <summary>
		/// The <see cref="Items" /> property's name.
		/// </summary>
		public const string ItemsPropertyName = "Items";

		private List<EmployeeViewModel> _items = null;

		/// <summary>
		/// Sets and gets the Items property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public List<EmployeeViewModel> Items
		{
			get
			{
				return _items;
			}

			set
			{
				if (_items == value)
				{
					return;
				}

				_items = value;
				RaisePropertyChanged(ItemsPropertyName);
			}
		}

		private RelayCommand _doCommand;

		/// <summary>
		/// Gets the DoCommand.
		/// </summary>
		public RelayCommand DoCommand
		{
			get
			{
				return _doCommand
						?? (_doCommand = new RelayCommand(
						() =>
						{
							MessageBox.Show("Enter");
						}));
			}
		}

		private RelayCommand _getItemsCommand;

		/// <summary>
		/// Gets the GetItemsCommand.
		/// </summary>
		public RelayCommand GetItemsCommand
		{
			get
			{ 
				return _getItemsCommand
						?? (_getItemsCommand = new RelayCommand(
						() =>
						{
							var items = from i in Enumerable.Range(1, 5)
								select new EmployeeViewModel()
								{
									Employee = new Employee() {
										Name = "Name " + i.ToString()
									}
								};
							Items = items.ToList();
						}));
			}
		}
	}
}