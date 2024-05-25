using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.EventSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen.Commands
{
    public class SignUpViewModel : ObservableObject, IErrorSupport
    {
        public event EventHandler<ErrorEventArgs> OnError;

        public SignUpViewModel()
        {
            OnError += (I, K) => { MessageBox.Show(K.ErrorMessage); };
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(); }
        }

        private string _eMail;

        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private UserType _userType;

        public UserType UserType
        {
            get { return _userType; }
            set { _userType = value; OnPropertyChanged(); }
        }

        private string _phoneNumber;

        public string Number
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public RelayCommand RadioButtonCommand
        {
            get
            {
                return new RelayCommand((I) =>
                {
                    bool parseControl = Enum.TryParse(typeof(UserType), I.ToString(), true, out object result);

                    if (parseControl)
                    {
                        UserType = (UserType)result;
                    }
                });
            }
        }


        public RelayCommand SignUpButtonCommand
        {
            get
            {
                return new RelayCommand((I) =>
                {
                    Authentication authentication = new Authentication();
                    bool result = false;

                    switch (UserType)
                    {
                        case UserType.Person:

                            result = authentication.SignUp(new Person() { Name = this.Name, LastName = this.Surname, Email = this.EMail, Password = this.Password, PhoneNumber = this.Number });
                            break;

                        case UserType.BusinessPerson:
                            result = authentication.SignUp(new BusinessPerson() { Name = this.Name, LastName = this.Surname, Email = this.EMail, Password = this.Password, PhoneNumber = this.Number });
                            break;
                    }

                    if (!result)
                    {
                        OnError.Invoke(this, new ErrorEventArgs("Login Process Failed! Try Again"));
                    }
                    else
                    {
                        MessageBox.Show("You have been successfully registered.","Information",MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                });
            }
        }

    }
}
