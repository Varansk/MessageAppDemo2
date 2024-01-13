using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo.Backend.DataBase.Repositorys;
using MessageAppDemo.Backend.SystemData.ChangeController;
using MessageAppDemo.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo.Backend.Users.UserData;
using MessageAppDemo.Backend.Users.UserManagers.Managers.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.Users.UserManagers.Managers
{
    public class AdminManager : IUserManager<Admin, Guid>
    {
        public void Add(Admin Item)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
           
            UserRepository.Add(Item);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }

        public Admin GetByID(Guid ID)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User user = UserRepository.GetByID(ID);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);

            return user as Admin;
        }

        public void Remove(Guid ID)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            foreach (ChatBase item in UserRepository.GetByID(ID).PersonalChatList.ListOfChats)
            {
                ChatRepository.UpdateWithPatch(item.ChatID, I =>
                {
                    I.ChatUsers.Remove(UserRepository.GetByID(ID), new UserController());
                });
            }

            UserRepository.Remove(ID);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
        }

        public void Update(Guid ID, Action<Admin> Changes)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            UserRepository.UpdateWithPatch(ID, I =>
            {
                Changes.Invoke(UserRepository.GetByID(ID) as Admin);
            });


            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }
    }
}
