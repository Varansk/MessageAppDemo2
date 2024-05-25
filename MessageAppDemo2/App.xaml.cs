using MessageAppDemo2.Backend.Chatting.ChatActions;
using MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers;
using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.BasicDatabasePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ChatRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.MessageRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.ReportRepository;
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.UserRepository;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
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
            #region DatabaseRepositorys
            VirtualDatabaseUserRepository virtualDatabaseUserRepository = new(virtualDatabase);
            VirtualDatabaseChatRepository virtualDatabaseChatRepository = new(virtualDatabase);
            VirtualDatabaseMessageRepository virtualDatabaseMessageRepository = new(virtualDatabase, null);
            VirtualDatabaseReportRepository virtualDatabaseReportRepository = new(virtualDatabase);
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


            #region TestArea
            Guid[] gds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            Admin admin = new Admin(gds[0]);
            BusinessPerson person = new BusinessPerson(gds[1]);
            Person personnormal = new(gds[2]);

            NormalChat normalChat = new NormalChat(gds[3]);
            GroupChat groupChat = new GroupChat(gds[4]);
            NormalChat normalChat1 = new NormalChat(gds[5]);


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
            userManager.Add(personManager, personnormal);
            userManager.Add(businessPersonManager, person);

            chatManager.Add(groupChatManager, groupChat);
            chatManager.Add(normalChatManager, normalChat);
            chatManager.Add(normalChatManager, normalChat1);

            chatUserManager.JoinChat(groupChatUserManager, groupChat, personnormal);
            chatUserManager.JoinChat(groupChatUserManager, groupChat, admin);
            chatUserManager.JoinChat(groupChatUserManager, groupChat, person);

            chatUserManager.JoinChat(normalChatUserManager, normalChat, person);
            chatUserManager.JoinChat(normalChatUserManager, normalChat, personnormal);

            personUserManager.AddFriend(personnormal, person);
            personUserManager.AddFriend(personnormal, admin);
            businessPersonUserManager.AddFriend(person, admin);





            adm.BanUser(UserRepository.GetByID(gds[0]) as Admin, UserRepository.GetByID(gds[1]), new BanInformation("ban", 4, Backend.SystemData.Enums.Level.Medium, UserRepository.GetByID(gds[0])));



            

            adminManager.Remove(gds[0]);


            #endregion
        }
    }
}
