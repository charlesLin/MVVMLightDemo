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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var uc = new LogMessageUserControl();
			ControllerContainer.Items.Add(uc);
		}

		private void AddConfirmMessageClick(object sender, RoutedEventArgs e)
		{
			var uc = new ConfirmMessageUserControl();
			ControllerContainer.Items.Add(uc);
		}

		private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
		{
			//Messenger.Default.Register<LogMessage>(this, (m) =>
			//{
			//	var log = string.Format("{0} at {1: HHmmss}", m.Message, m.Timestamp);
			//	MessageListView.Items.Add(log);
			//});

			//Messenger.Default.Register<ConfirmMessage>(this, (m) =>
			//{
			//	var isConfirm = m.Confirm();
			//	var log = string.Format("{0}, you agree that? {1},  at {2: HHmmss}", m.Message, isConfirm, m.Timestamp);
			//	MessageListView.Items.Add(log);
			//});


			Messenger.Default.Register<NotificationMessage<ConfirmMessage>>(this, (m) =>
			{
				var isConfirm = m.Content.Confirm();
				var confirmMessage = m.Content;
				//var log = string.Format("{0}, you agree that? {1},  at {2: HHmmss}", 
				//	confirmMessage.Message, isConfirm, confirmMessage.Timestamp);
				var vm = new LogMessageViewModel() { IsConfirm = isConfirm, NotificationMessage = m};
				MessageListView.Items.Add(vm);
			});
		}

		private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var vm = ((FrameworkElement) sender).DataContext as LogMessageViewModel;
			var origUC = vm.NotificationMessage.Sender as UserControl;
			origUC.Background = new SolidColorBrush(Colors.Red);
		}
	}
}
