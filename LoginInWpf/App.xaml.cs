using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LoginInWpf
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
			var loginWindow = new LoginWindow();
			loginWindow.ShowDialog();
			if (loginWindow.DialogResult == true)
			{
				App.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
				var main = new MainWindow();
				main.Show();
			}
			else
			{
				App.Current.Shutdown();
			}
			base.OnStartup(e);
		}
	}
}
