﻿using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.Users.UserManagers.Managers.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.Users.UserManagers.Managers
{
    public class BusinessPersonManager : IUserManager<BusinessPerson, Guid>
    {
        public void Add(BusinessPerson Item)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            UserRepository.Add(Item);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }

        public BusinessPerson GetByID(Guid ID)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User user = UserRepository.GetByID(ID);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);

            return user as BusinessPerson;
        }

        public void Remove(Guid ID)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            /*
            foreach (ChatBase item in UserRepository.GetByID(ID).PersonalChatList.ListOfChats)
            {
                ChatRepository.UpdateWithPatch(item.ChatID, I =>
                {
                    I.ChatUsers.Remove(UserRepository.GetByID(ID), new UserController());
                });
            }
            */
            ChatUserManager ch = new();

            ch.LeaveAllChats(UserRepository.GetByID(ID));

            UserRepository.Remove(ID);

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
        }

        public void Update(Guid ID, Action<BusinessPerson> Changes)
        {
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            UserRepository.UpdateWithPatch(ID, I =>
            {
                Changes.Invoke(UserRepository.GetByID(ID) as BusinessPerson);
            });


            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }
    }
}
