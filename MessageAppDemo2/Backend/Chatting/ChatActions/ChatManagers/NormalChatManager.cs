﻿using MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers
{
    public class NormalChatManager : IChatManager<NormalChat, Guid>
    {
        public void Add(NormalChat Item)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            NormalChatUserManager NormalChatUserManager = new();

            ChatRepository.Add(Item);

            foreach (User Useritem in Item.ChatUsers)
            {
                UserRepository.UpdateWithPatch(Useritem.UserGUİD, I =>
                {
                    NormalChatUserManager.JoinChat(Item, Useritem);
                });
            }

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }




        public NormalChat GetByID(Guid ID)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            NormalChat Chat = ChatRepository.GetByID(ID) as NormalChat;

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);

            return Chat;
        }


        public void Remove(Guid ID)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            NormalChatUserManager NormalChatUserManager = new();

            NormalChat Chat = ChatRepository.GetByID(ID) as NormalChat;

            if (Chat == null)
            {
                return;
            }

            foreach (User item in Chat.ChatUsers)
            {
                UserRepository.UpdateWithPatch(item.UserGUİD, I =>
                {
                    NormalChatUserManager.LeaveChat(Chat, item.UserGUİD);
                });
            }

            ChatRepository.Remove(ID);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }

        public void Update(Guid ID, Action<NormalChat> Changes)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            ChatRepository.UpdateWithPatch(ID, I =>
            {
                Changes.Invoke(I as NormalChat);
            });

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
        }
    }
}
