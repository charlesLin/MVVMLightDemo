using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

		/// <summary>
		/// Sets and gets the Password property.
		/// Changes to that property's value raise the PropertyChanged event. 
		/// </summary>
		public string Password
		{
			get
			{
				return _password;
			}

			set
			{
				if (_password == value)
				{
					return;
				}

				_password = value;
				RaisePropertyChanged(PasswordPropertyName);
			}
		}

		private RelayCommand<string> _loginCommand;

		/// <summary>
		/// Gets the LoginCommand.
		/// </summary>
		public RelayCommand<string> LoginCommand
		{
			get
			{
				return _loginCommand
						?? (_loginCommand = new RelayCommand<string>(ExecuteLoginCommand, (s) =>
						{
							return (!string.IsNullOrEmpty(Account));
						}));
			}
		}



		private void ExecuteLoginCommand(string password)
		{
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
