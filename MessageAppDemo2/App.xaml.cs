using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.Connections;
using MessageAppDemo.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.BasicDatabasePool;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo.Backend.DataBase.Repositorys;
using MessageAppDemo.Backend.DataBase.Repositorys.AllRepositorys.ChatRepository;
using MessageAppDemo.Backend.DataBase.Repositorys.AllRepositorys.MessageRepository;
using MessageAppDemo.Backend.DataBase.Repositorys.AllRepositorys.UserRepository;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.Users.UserData;
using System;
using System.Windows;

namespace MessageAppDemo
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
            #endregion

            #region TestArea

            #endregion
        }
    }
}
