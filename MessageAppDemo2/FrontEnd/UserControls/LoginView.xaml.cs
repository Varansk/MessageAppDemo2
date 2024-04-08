using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MessageAppDemo2.FrontEnd.UserControls
{
    /// <summary>
    /// LoginView.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginView : UserControl
    {
        private Login_SignUpViewModel _loginSignUpViewModel = new();

        public LoginView()
        {          
          
            InitializeComponent();          
            this.DataContext = _loginSignUpViewModel;
        }

        
    }
}
