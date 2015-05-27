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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace MessengerDemo
{
	/// <summary>
	/// Interaction logic for LogMessageUserControl.xaml
	/// </summary>
	public partial class ConfirmMessageUserControl : UserControl
	{
		public ConfirmMessageUserControl()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var log = new ConfirmMessage("I am Charles", () =>
			{
				var result = MessageBox.Show("I agree!", "Confirm", MessageBoxButton.YesNo);
				return result == MessageBoxResult.Yes;
			});
			//Messenger.Default.Send(log);
			Messenger.Default.Send(new NotificationMessage<ConfirmMessage>(this, log, "sss"));
		}
	}
}
