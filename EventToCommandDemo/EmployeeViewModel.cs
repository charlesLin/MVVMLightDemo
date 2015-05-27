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
	public class EmployeeViewModel : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the EmployeeViewModel class.
		/// </summary>
		public EmployeeViewModel()
		{
		}

		/// <summary>
		/// The <see cref="Employee" /> property's name.
		/// </summary>
		public const string EmployeePropertyName = "Employee";

		private Employee _employee = null;

		/// <summary>
		/// Sets and gets the Employee property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public Employee Employee
		{
			get
			{
				return _employee;
			}

			set
			{
				if (_employee == value)
				{
					return;
				}

				_employee = value;
				RaisePropertyChanged(EmployeePropertyName);
			}
		}

		private RelayCommand _showNameCommand;

		/// <summary>
		/// Gets the ShowNameCommand.
		/// </summary>
		public RelayCommand ShowNameCommand
		{
			get
			{
				return _showNameCommand
						?? (_showNameCommand = new RelayCommand(
						() =>
						{
							MessageBox.Show(Employee.Name);
						}));
			}
		}

	}
}