using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LoginInWpf.ViewModels;

namespace LoginInWpf
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
			var vm = this.DataContext as LoginViewModel;
			vm.LoginAction = () =>
			{
				this.DialogResult = true;
				this.Close();
			};
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
	}
}
