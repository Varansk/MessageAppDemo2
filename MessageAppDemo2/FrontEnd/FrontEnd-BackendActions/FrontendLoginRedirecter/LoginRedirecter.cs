using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.FrontendLoginRedirecter
{
    public class LoginRedirecter
    {
        private LoginFactory _loginFactory;

        public LoginRedirecter()
        {
            _loginFactory = new LoginFactory();
        }


        public void Redirect(ContentControl Window, UserType Type)
        {
            UserControl UC = _loginFactory.CreateInstance(Type);

            Window.Content = UC;
        }

        public void Redirect(ContentControl Window, UserType Type, object[] Parameters)
        {
            UserControl UC = _loginFactory.CreateInstanceWithParameter(Type, Parameters);


            Window.Content = UC;
        }
    }
}
