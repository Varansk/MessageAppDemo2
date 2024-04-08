using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.ValueChecksAndControls;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.EventSupport;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.FrontendLoginRedirecter;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels
{
    public class LoginViewModel : ObservableObject, IErrorSupport
    {
        public LoginViewModel()
        {
            OnError += (I, K) => { MessageBox.Show(K.ErrorMessage); };
        }
        private string _number = string.Empty;
        private string _password = string.Empty;

        public event EventHandler<ErrorEventArgs> OnError;

        public string Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        public RelayCommand buttonCommand
        {
            get
            {
                return new RelayCommand(I =>
                {
                    Authentication authentication = new();
                    bool result = authentication.Login(new Person() { Password = this.Password, PhoneNumber = this.Number });

                    if (!result)
                    {
                        OnError.Invoke(this, new ErrorEventArgs("Login Process Failed! Try Again"));
                    }
                    else
                    {
                        LoginRedirecter LG = new LoginRedirecter();

                        LG.Redirect(Application.Current.MainWindow, UserType.Person);
                    }
                });
            }
        }


    }
}
