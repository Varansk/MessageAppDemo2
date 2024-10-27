using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageUserActions;
using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.LoginSignupScreen.Commands;
using MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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


        private Dictionary<string, ObservableCollection<MessageBase>> _messages;
        public Dictionary<string, ObservableCollection<MessageBase>> Messages
        {
            get { return _messages; }
            set { _messages = value; OnPropertyChanged(); }
        }


        public ChatCardDetails LastMessageDetails
        {
            get
            {
                return ChatCardDetails.GetChatDetails(_messages[UserChats[0].ChatID.ToString()].Last());
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



        public ChatBase _chatListSelectedItem;

        public ChatBase ChatListSelectedItem
        {
            get { return _chatListSelectedItem; }
            set { _chatListSelectedItem = value; OnPropertyChanged(); }

        }


        private string _MessageText;

        public string MessageText
        {
            get { return _MessageText; }
            set { _MessageText = value; OnPropertyChanged(); }
        }

        private ObservableCollection<UploadedFile> _WaitintFiles;

        public ObservableCollection<UploadedFile> WaitingFiles
        {
            get { return _WaitintFiles; }
            set { _WaitintFiles = value; OnPropertyChanged(); }
        }





        public RelayCommand SendMessageCommand { get; private set; }
        public RelayCommand DragDropCommand { get; private set; }




        private MessageUserManager _messageUserManager;










        public PersonScreenMainViewModel()
        {
            WaitingFiles = new ObservableCollection<UploadedFile>();

            _messageUserManager = new MessageUserManager();

            this._userChats = new ObservableCollection<ChatBase>()
             {
                new GroupChat(Guid.NewGuid()) { ChatName = "FDJ beste", ChatDetails = "North, South", ChatPicture = IconResources.NoImageIcon.ToBitmapImage() },
                new GroupChat(Guid.NewGuid()) { ChatName = "KpdML beste", ChatDetails = "East, West", ChatPicture = IconResources.mute.ToBitmapImage() }
             };

            _userChats = new ObservableCollection<ChatBase>(User.PersonalChatList.ListOfChats);

            _messages = (User.PersonalChatList.ListOfChats.Select((I) =>
             {
                 var messages = new ObservableCollection<MessageBase>(_messageUserManager.GetLastxxMessage(200, I.ChatID.ToString(), ".main"));

                 return new KeyValuePair<string, ObservableCollection<MessageBase>>(I.ChatID.ToString(), messages);
             })).ToDictionary();








            DragDropCommand = new RelayCommand((I) =>
            {
                if (I is not DragEventArgs)
                {
                    MessageBox.Show("File Drop Error.");
                    return;
                }

                DragEventArgs e = (DragEventArgs)I;

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] DataPaths = e.Data.GetData(DataFormats.FileDrop) as string[];

                    foreach (string item in DataPaths)
                    {
                        WaitingFiles.Add(new UploadedFile(item));
                    }
                }
            });



            SendMessageCommand = new RelayCommand((I) =>
            {            
                
               // _messageUserManager.SendMessage()
            });
        }



    }
}
