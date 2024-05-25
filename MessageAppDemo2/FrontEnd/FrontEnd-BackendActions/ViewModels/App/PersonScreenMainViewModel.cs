using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App
{
    public class PersonScreenMainViewModel : ObservableObject
    {
        private ObservableCollection<ChatBase> _userChats;

        public ObservableCollection<ChatBase> UserChats
        {
            get { return _userChats; }
            set { _userChats = value; OnPropertyChanged(); }
        }

        public Person User
        {
            get
            {
                User user = LoggedUserPool.GetLoggedUser();
                LoggedUserPool.ReturnLoggedUser(user);

                return user as Person;
            }
            set
            {
                LoggedUserPool.AddLoggedUser(value);
                OnPropertyChanged();
            }
        }


        public PersonScreenMainViewModel()
        {

        }

    }
}
