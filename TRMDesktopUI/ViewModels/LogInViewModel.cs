using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Helper;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.ViewModels
{
    public class LogInViewModel : Screen
    {
		private string _userName;
		private string _password;
		private APIHelper _ApiHelper = new APIHelper();

		public string UserName
		{
			get { return _userName; }
			set 
			{
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanLogIn);
			}
		}

		public bool CanLogIn
		{
			get
			{
				bool output = false;

				if (UserName?.Length > 0 && Password?.Length > 0)
				{
					output = true;
				}
				return output;
			}
		}

		public async Task LogIn()
		{
			try
			{
				AuthenticatedUser result = await _ApiHelper.Authenticate(UserName, Password);
			}
			catch (Exception ex)
			{
				Console.WriteLine("");
			}
		}
	}
}
