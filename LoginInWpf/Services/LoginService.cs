using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginInWpf.Services
{
	public class LoginService
	{
		public bool ValidateUser(string account, string password)
		{
			if ((account == "admin") && (password == "bankpro"))
				return true;
			return false;
		}
	}
}
