using MessageAppDemo2.Backend.Chatting.ChatActions;
using MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers;
using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.BasicDatabasePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.BasicRealTimePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RealTimeServicePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.RealTimeConneciton;
using MessageAppDemo2.Backend.DataBase.RealTimeConneciton.Interfaces;
using MessageAppDemo2.Backend.DataBase.RealTimeConnections;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ChatRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.MessageRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ReportRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.UserRepository;
using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Message.MessageActions;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageUserActions;
using MessageAppDemo2.Backend.PersonalData;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.Users.UserManagers;
using MessageAppDemo2.Backend.Users.UserManagers.Managers;
using MessageAppDemo2.Backend.Users.UserManagers.Managers.Factory;
using MessageAppDemo2.Backend.Users.UserUserManager;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MessageAppDemo2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region BasicDatabase
            VirtualDatabase virtualDatabase = new();
            #endregion
            #region BasicAMQP
            RabbitMQConnection connection = new RabbitMQConnection("amqps://kjkqiepn:u_v7vdMgZ4tuIrmdjUo1A9z50Ip7t4lt@cow.rmq2.cloudamqp.com/kjkqiepn");
            #endregion

            #region DatabaseRepositorys
            VirtualDatabaseUserRepository virtualDatabaseUserRepository = new(virtualDatabase);
            VirtualDatabaseChatRepository virtualDatabaseChatRepository = new(virtualDatabase);
            VirtualDatabaseMessageRepository virtualDatabaseMessageRepository = new(virtualDatabase, Guid.Empty, "");
            VirtualDatabaseReportRepository virtualDatabaseReportRepository = new(virtualDatabase);
            #endregion
            #region RealTimeService
            RabbitMQMessageQueueService<MessageBase> RabbitMQMessageService = new(connection);
            #endregion

            #region BasicDatabasePoolActions
            DataBaseConnect DataBaseConnect = new(virtualDatabase);
            DataBaseConnect.AddToDatabasePool("DTB");
            #endregion
            #region DatabaseRepositoryPoolActions
            DatabaseRepository<User, Guid> UserRepository = new(virtualDatabaseUserRepository);
            UserRepository.AddToDatabaseUserRepositoryPool("DTBR");

            DatabaseRepository<ChatBase, Guid> ChatRepository = new(virtualDatabaseChatRepository);
            ChatRepository.AddToDatabaseChatRepositoryPool("DTBR");

            DatabaseRepository<MessageBase, int> MessageRepository = new(virtualDatabaseMessageRepository);
            MessageRepository.AddToDatabaseMessageRepositoryPool("DTBR");

            DatabaseRepository<ReportBase, Guid> ReportRepository = new(virtualDatabaseReportRepository);
            ReportRepository.AddToDatabaseReportRepositoryPool("DTBR");
            #endregion


            #region BasicAMQPActions
            RealTimeConnect realTimeConnect = new(connection);
            realTimeConnect.AddRealTimePool("RTS");
            #endregion
            #region RealTimeServicePoolActions
            RealTimeService<MessageBase> realTimeService = new(RabbitMQMessageService);
            realTimeService.AddToRealTimeMessageServicePool("RTS");
            #endregion




            #region TestArea
            Guid[] gds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            Admin admin = new Admin(gds[0]) { BirthDay = Convert.ToDateTime("11/11/2000"), Email = "johnengels@gmail.com", Name = "John", LastName = "Engels", Password = "Defaultpassword.?543210JE", FirstRegisteredDay = Convert.ToDateTime("11/11/2020"), ProfilePicture = IconResources.NoImageIcon.ToBitmapImage(), PhoneNumber = "2520475045", UserSignature = "Gold" };

            BusinessPerson businessperson = new BusinessPerson(gds[1]) { BirthDay = Convert.ToDateTime("15/10/1995"), Email = "mariamarx@gmail.com", Name = "Maria", LastName = "Marx", Password = "Defaultpassword.?543210MM", FirstRegisteredDay = Convert.ToDateTime("15/10/2015"), ProfilePicture = IconResources.NoImageIcon.ToBitmapImage(), PhoneNumber = "2270773065", UserSignature = "Silisium" };

            Person person = new(gds[2])
            { BirthDay = Convert.ToDateTime("2/1/1965"), Email = "alberthusson@gmail.com", Name = "Albert", LastName = "Husson", Password = "Defaultpassword.?543210AH", FirstRegisteredDay = Convert.ToDateTime("2/1/2005"), ProfilePicture = IconResources.NoImageIcon.ToBitmapImage(), PhoneNumber = "1260673055", UserSignature = "Germanium " };

            NormalChat normalChat = new NormalChat(gds[3]) { ChatDetails = "East West" };
            GroupChat groupChat = new GroupChat(gds[4]) { ChatName = "FDJ beste", ChatDetails = "North, South", ChatPicture = IconResources.archive.ToBitmapImage() };
            NormalChat normalChat1 = new NormalChat(gds[5]) { ChatDetails = "South East" };


            ChatUserManager chatUserManager = new();
            NormalChatUserManager normalChatUserManager = new();
            GroupChatUserManager groupChatUserManager = new();

            PersonUserManager personUserManager = new();
            AdminUserManager adm = new();
            BusinessPersonUserManager businessPersonUserManager = new();

            UserManager userManager = new();
            AdminManager adminManager = new();
            PersonManager personManager = new();
            BusinessPersonManager businessPersonManager = new();

            GroupChatManager groupChatManager = new();
            NormalChatManager normalChatManager = new();
            ChatManager chatManager = new();

            userManager.Add(adminManager, admin);
            userManager.Add(personManager, person);
            userManager.Add(businessPersonManager, businessperson);

            chatManager.Add(groupChatManager, groupChat);
            chatManager.Add(normalChatManager, normalChat);
            chatManager.Add(normalChatManager, normalChat1);

            chatUserManager.JoinChat(groupChatUserManager, groupChat, person);
            chatUserManager.JoinChat(groupChatUserManager, groupChat, admin);
            chatUserManager.JoinChat(groupChatUserManager, groupChat, businessperson);

            chatUserManager.JoinChat(normalChatUserManager, normalChat, businessperson);
            chatUserManager.JoinChat(normalChatUserManager, normalChat, person);

            personUserManager.AddFriend(person, businessperson);
            personUserManager.AddFriend(person, admin);
            businessPersonUserManager.AddFriend(businessperson, admin);



            LoggedUserPool.AddLoggedUser(person);




            MessageUserManager messageUserManager = new MessageUserManager();






            /* real.SendMessage(groupChat.ChatID.ToString(), ".main.Added", new ProcessedMessage<MessageBase> { MessageID = "5", MessageSended = Convert.ToDateTime("01/10/2007"), MessageAction = MessageAction.Add, MessageChannelName = groupChat.ChatID.ToString(), MessageSenderID = person.UserGUİD.ToString(), RoutingKey = ".main.Added", Message = new TextMessage() { Text = "Helllooo", WhichChatMessageSent = groupChat, MessageID = 5, IsEdited = false, MessageSender = person, MessageSentDate = Convert.ToDateTime("01/10/2007") } });
             */

            var list = new Dictionary<string, List<ProcessedMessage<MessageBase>>>();
            var list2 = new Dictionary<string, List<ProcessedMessage<MessageBase>>>();


            var tags = messageUserManager.StartConsumeMessages(groupChat.ChatID.ToString(), ".main", list);
            // var tags2 = messageUserManager.StartConsumeMessages(normalChat.ChatID.ToString(), ".main.RR", list2);


            messageUserManager.SendMessage(new TextMessage() { Text = "Hello1", WhichChatMessageSent = groupChat, MessageID = 5, IsEdited = false, MessageSender = person, MessageSentDate = Convert.ToDateTime("01/10/2007"), ChatRoute = ".main", DependentChatGuid = groupChat.ChatID, MessageSenderID = gds[2] }, groupChat.ChatID.ToString(), ".main", gds[2].ToString());

            messageUserManager.SendMessage(new TextMessage() { Text = "Hello2", WhichChatMessageSent = groupChat, MessageID = 6, IsEdited = false, MessageSender = person, MessageSentDate = Convert.ToDateTime("01/10/2007"), ChatRoute = ".main", DependentChatGuid = groupChat.ChatID, MessageSenderID = gds[2] }, groupChat.ChatID.ToString(), ".main", gds[2].ToString());

            messageUserManager.EditMessage("6", groupChat.ChatID.ToString(), ".main", new TextMessage() { Text = "AQWDA", WhichChatMessageSent = groupChat, MessageID = 6, IsEdited = false, MessageSender = person, MessageSentDate = Convert.ToDateTime("01/10/2007"), ChatRoute = ".main", DependentChatGuid = groupChat.ChatID, MessageSenderID = gds[2] }, gds[2].ToString());

            //   messageUserManager.RemoveMessage(MessageType.TextMessage, 5.ToString(), groupChat.ChatID.ToString(), ".main");



            MessageBase x = new VideoMessage() { Text = "İMMM", WhichChatMessageSent = normalChat, MessageID = 2, IsEdited = false, MessageSender = person, MessageSentDate = Convert.ToDateTime("01/10/2007"), ChatRoute = ".main", DependentChatGuid = normalChat.ChatID, MessageSenderID = gds[2] };
            messageUserManager.SendMessage(x, normalChat.ChatID.ToString(), ".main.RR", gds[2].ToString());


            messageUserManager.StopConsumeMessages(tags);
            //messageUserManager.StopConsumeMessages(tags2);
            /*
                        for (int i = 0; i < 100; i++)
                        {           
                            MessageBox.Show("H");      
                        }

                        */





            #endregion
        }
    }
}
