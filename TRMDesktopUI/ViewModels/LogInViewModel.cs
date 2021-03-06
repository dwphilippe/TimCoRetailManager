﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Helper;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.ViewModels
{
    public class LogInViewModel : Screen
    {
		private string _userName= "philippe@countryit.be";
		private string _password = "Pdw12345.";
		private IAPIHelper _apiHelper;
		private IEventAggregator _events;

		public LogInViewModel(IAPIHelper apiHelper, IEventAggregator events)
		{
			_apiHelper = apiHelper;
			_events = events;
		}

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

		public bool IsErrorVisable 
		{
			get
			{
				return (ErrorMessage?.Length > 0);
			}
		}

		private string _errorMessage;

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set 
			{ 
				_errorMessage = value;
				NotifyOfPropertyChange(() => ErrorMessage);
				NotifyOfPropertyChange(() => IsErrorVisable);
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
			ErrorMessage = "";
			try
			{
				AuthenticatedUser result = await _apiHelper.Authenticate(UserName, Password);
				await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

				_events.PublishOnUIThread(new LogOnEvent());
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
