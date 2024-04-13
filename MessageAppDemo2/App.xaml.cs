using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
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
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserManagers;
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

            DatabaseRepository<ReportBase,Guid> ReportRepository = new(virtualDatabaseReportRepository);
            ReportRepository.AddToDatabaseReportRepositoryPool("DTBR");
            #endregion


            #region TestArea

           
            

            

            
           


            #endregion
        }
    }
}
