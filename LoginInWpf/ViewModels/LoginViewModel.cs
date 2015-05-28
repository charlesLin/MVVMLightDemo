using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.CommandWpf;
using LoginInWpf.Annotations;

namespace LoginInWpf.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Action LoginAction = () => { };

		/// <summary>
		/// The <see cref="Account" /> property's name.
		/// </summary>
		public const string AccountPropertyName = "Account";

		private string _account = null;

		public string Account
		{
			get
			{
				return _account;
			}

			set
			{
				if (_account == value)
				{
					return;
				}

				_account = value;
				RaisePropertyChanged(AccountPropertyName);
			}
		}


		/// <summary>
		/// The <see cref="Password" /> property's name.
		/// </summary>
		public const string PasswordPropertyName = "Password";

		private string _password = null;

		private RelayCommand<PasswordBox> _loginCommand;

		/// <summary>
		/// Gets the LoginCommand.
		/// </summary>
		public RelayCommand<PasswordBox> LoginCommand
		{
			get
			{
				return _loginCommand
						?? (_loginCommand = new RelayCommand<PasswordBox>(ExecuteLoginCommand, (s) =>
						{
							return (!string.IsNullOrEmpty(Account) && !string.IsNullOrEmpty(s.Password));
						}));
			}
		}



		private void ExecuteLoginCommand(PasswordBox box)
		{
			Debug.WriteLine(box.Password);
			LoginAction();
		}

		[NotifyPropertyChangedInvocator]
		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
