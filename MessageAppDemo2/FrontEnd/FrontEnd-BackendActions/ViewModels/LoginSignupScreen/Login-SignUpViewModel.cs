using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen
{
    public class Login_SignUpViewModel : ObservableObject
    {

        public Login_SignUpViewModel()
        {
            this._loginViewModel = new();
            this._signUpViewModel = new();
        }

        private LoginViewModel _loginViewModel;
        private SignUpViewModel _signUpViewModel;

        public LoginViewModel LoginViewModel
        {
            get { return _loginViewModel; }
            set { _loginViewModel = value; OnPropertyChanged(); }
        }

        public SignUpViewModel SignUpViewModel
        {
            get { return _signUpViewModel; }
            set { _signUpViewModel = value; OnPropertyChanged(); }
        }

    }
}
