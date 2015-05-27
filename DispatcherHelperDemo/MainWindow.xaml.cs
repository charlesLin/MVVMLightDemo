using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace DispatcherHelperDemo
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


		private int GetContentLength()
		{
			var client = new WebClient();
			client.Encoding = Encoding.UTF8;
			var content =  client.DownloadString("http://news.baidu.com/?tt=" + DateTime.Now.Ticks);
			var length = content.Length;
			return length;
		}
	}
}
