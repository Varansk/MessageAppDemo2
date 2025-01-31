using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageUserActions;
using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.SystemData.IFactory;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.ConvertersAndMarkupExt;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.HelperClasses;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App
{


    public class PersonScreenMainViewModel : ObservableObject
    {
        #region ChatPropertys
        private ObservableCollection<ChatBase> _userChats;
        public ObservableCollection<ChatBase> UserChats
        {
            get { return _userChats; }
            set { _userChats = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ChatCardInstance> UserChatModels
        {
            get
            {
                IEnumerable<ChatCardInstance> list = UserChats.Select((I) =>
                {
                    ChatCardDetails details;

                    if (Messages[I.ChatID.ToString()].Any())
                    {
                        details = ChatCardDetails.GetChatDetails(Messages[I.ChatID.ToString()].Last());
                    }
                    else
                    {
                        details = new ChatCardDetails(new TextMessage(), MessageType.TextMessage, "There is No Message", IconResources.empty.ToBitmapImage(), "");
                    }



                    ChatCardInstance chatCardInstance = new ChatCardInstance()
                    {
                        Chat = I,
                        ChatName = I.ChatName,
                        LastMessage = details.LastMessageFormatted,
                        LastMessageLogo = details.LastMessageSideLogo,
                        LastMessageSenderName = details.UserNameFormatted,
                        MainImage = I.ChatPicture,
                        NonReadMessageCount = 0
                    };

                    return chatCardInstance;
                });


                ObservableCollection<ChatCardInstance> chatcard = new ObservableCollection<ChatCardInstance>(list);


                return chatcard;

            }
        }


        public ChatCardInstance _chatListSelectedItem;

        public ChatCardInstance ChatListSelectedItem
        {
            get { return _chatListSelectedItem ?? new ChatCardInstance(); }
            set
            {
                _chatListSelectedItem = value;
                if (_chatListSelectedItem is not null && _chatListSelectedItem.Chat is not null)
                {
                    ToBeSelectedMessageList = Messages[_chatListSelectedItem.Chat.ChatID.ToString()];
                }

                OnPropertyChanged();
            }

        }

        #endregion


        #region MessagePropertys
        private Dictionary<string, ObservableCollection<MessageBase>> _messages;
        public Dictionary<string, ObservableCollection<MessageBase>> Messages
        {
            get { return _messages; }
            set { _messages = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MessageBase> _messageList;
        public ObservableCollection<MessageBase> ToBeSelectedMessageList
        {
            get
            {
                return _messageList;

            }
            set
            {
                _messageList = value;
                OnPropertyChanged();
            }

        }
        #endregion


        #region User
        public Person LoggedUser
        {
            get
            {
                Person person = LoggedUserPool.GetLoggedUser() as Person;
                LoggedUserPool.ReturnLoggedUser(person);

                return person;
            }
            set
            {
                LoggedUserPool.AddLoggedUser(value);
                OnPropertyChanged();
            }
        }
        #endregion


        #region NonSendedMessage

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

        #endregion


        #region Commands
        public RelayCommand SendMessageCommand { get; private set; }
        public RelayCommand DragDropCommand { get; private set; }
        #endregion


        #region HelperPropertys
        private MessageUserManager _messageUserManager;
        #endregion


        public PersonScreenMainViewModel()
        {
            _messageUserManager = new MessageUserManager();

            WaitingFiles = new ObservableCollection<UploadedFile>();
            _userChats = new ObservableCollection<ChatBase>(LoggedUser.PersonalChatList.ListOfChats);


            _messages = (LoggedUser.PersonalChatList.ListOfChats.Select((I) =>
             {
                 var messages = new ObservableCollection<MessageBase>(_messageUserManager.GetLastxxMessage(30, I.ChatID.ToString(), ".main")); //

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
                if (!string.IsNullOrWhiteSpace(MessageText))
                {
                    MessageBox.Show("heey");

                    Type typeofmessage = DedectSendindMessageType.DedectTypeReturnType(WaitingFiles, MessageText);
                    MessageType type = DedectSendindMessageType.DedectType(WaitingFiles, MessageText);

                    MessageParameters messageParameters = new MessageParameters() { ChatRoute = ".main", DependentChatGuid = ChatListSelectedItem.Chat.ChatID, Files = WaitingFiles.ToList(), MessageSentDate = DateTime.Now, Text = MessageText, QuotedMessage = null, DependentChatMessageCount = 10, MessageSenderGuid = LoggedUser.UserGUİD };

                    MessageFactory messageFactory = new MessageFactory();

                    MessageBase message = messageFactory.CreateInstanceWithParameter(type, messageParameters);

                    

                    






                    _messageUserManager.SendMessage(message, ChatListSelectedItem.Chat.ChatID.ToString(), ".main", LoggedUser.UserGUİD.ToString());
                }

            });
        }



    }
}
