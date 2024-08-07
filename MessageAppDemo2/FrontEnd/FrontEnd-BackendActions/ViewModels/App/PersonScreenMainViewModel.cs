using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen.Commands;
using MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers;
using MessageAppDemo2.FrontEnd.Resources.Icons;
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
        private ObservableCollection<ChatBase> _userChats; /*= new ObservableCollection<ChatBase>()
        {
           new GroupChat(Guid.NewGuid()) { ChatName = "FDJ beste", ChatDetails = "North, South", ChatPicture = IconResources.NoImageIcon.ToBitmapImage() },
           new GroupChat(Guid.NewGuid()) { ChatName = "KpdML beste", ChatDetails = "East, West", ChatPicture = IconResources.mute.ToBitmapImage() }
        };*/

        public ObservableCollection<ChatBase> UserChats
        {
            get { return _userChats; }
            set { _userChats = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MessageBase> messages;

        public ObservableCollection<MessageBase> Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged(); }
        }

        public ChatCardDetails LastMessageDetails
        {
            get
            {
                return ChatCardDetails.GetChatDetails(messages.Last());
            }
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

        public RelayCommand GetChats;

        public PersonScreenMainViewModel()
        {
            GetChats = new RelayCommand((I) =>
            {
               

            });
        }

    }
}
