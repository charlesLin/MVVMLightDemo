using System;
using System.Net;
using System.Text;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;

namespace DispatcherHelperDemo
{
	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{

		}

		/// <summary>
		/// The <see cref="ContentLength" /> property's name.
		/// </summary>
		public const string ContentLengthPropertyName = "ContentLength";

		private int _contentLength = 0;

		/// <summary>
		/// Sets and gets the ContentLength property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public int ContentLength
		{
			get
			{
				return _contentLength;
			}

			set
			{
				if (_contentLength == value)
				{
					return;
				}

				_contentLength = value;
				RaisePropertyChanged(ContentLengthPropertyName);
			}
		}

		private RelayCommand _getCommand;

		/// <summary>
		/// Gets the GetCommand.
		/// </summary>
		public RelayCommand GetCommand
		{
			get
			{
				return _getCommand
						?? (_getCommand = new RelayCommand(
						() =>
						{
							var client = new WebClient();
							client.Encoding = Encoding.UTF8;
							var content = client.DownloadString("http://news.baidu.com/?tt=" + DateTime.Now.Ticks);
							var length = content.Length;
							ContentLength = length;
						}));
			}
		}
	}
}