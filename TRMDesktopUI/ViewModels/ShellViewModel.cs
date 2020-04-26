using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LogInViewModel _logInVM;

        public ShellViewModel(LogInViewModel logInVM)
        {
            _logInVM = logInVM;
            ActivateItem(_logInVM);
        }
    }
}
