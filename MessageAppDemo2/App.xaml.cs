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
using MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.UserRepository;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
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

            Person p1 = new Person() { PhoneNumber = "5510115042", Password = "Salih2007!adam", BirthDay = new DateTime(2000, 11, 15), Email = "erturksalih007@gmail.com", FirstRegisteredDay = DateTime.Now, Name = "Salih", LastName = "Ertürk", ProfilePicture = IconResources.NoImageIcon.ToImage(), UserGUİD = Guid.NewGuid(), UserSignature = "ben salih", UserType = UserType.Person };

            Person p2 = new Person() { PhoneNumber = "5315057742", Password = "Hamiyet2007!adam", BirthDay = new DateTime(1989, 4, 6), Email = "hmyt007@gmail.com", FirstRegisteredDay = DateTime.Now, Name = "Hamiyet", LastName = "Günaslan", ProfilePicture = IconResources.NoImageIcon.ToImage(), UserGUİD = Guid.NewGuid(), UserSignature = "ben hamiyet", UserType = UserType.Person };

            BusinessPerson p3 = new BusinessPerson() { PhoneNumber = "5353207241", Password = "Önder2007!adam", BirthDay = new DateTime(1981, 3, 25), Email = "ondertex@gmail.com", FirstRegisteredDay = DateTime.Now, Name = "Önder", LastName = "Ertürk", ProfilePicture = IconResources.NoImageIcon.ToImage(), UserGUİD = Guid.NewGuid(), UserSignature = "ben önder", UserType = UserType.BusinessPerson };

            Admin p4 = new Admin() { PhoneNumber = "5510115045", Password = "Eren2007!adam", BirthDay = new DateTime(2000, 11, 18), Email = "erenkıyak@gmail.com", FirstRegisteredDay = DateTime.Now, Name = "Eren", LastName = "Kıyak", ProfilePicture = IconResources.NoImageIcon.ToImage(), UserGUİD = Guid.NewGuid(), UserSignature = "ben eren", UserType = UserType.Admin };

            

           


            #endregion
        }
    }
}
