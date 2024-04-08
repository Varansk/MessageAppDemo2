﻿using Azure.Identity;
using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MessageAppDemo2.Backend.Chatting.ChatUserActions
{
    public class GroupChatUserManager : IBannableChatUserManager<Guid, GroupChat>
    {
        public bool BanUserFromChat(GroupChat Chat, User Banned)
        {
            if (Banned is null || Chat is null)
            {
                return false;
            }

            UserController userController = new UserController();
            ChatController chatController = new ChatController();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            bool IsChatContainsUser = Chat.ChatUsers.Contains(Banned, userController);
            bool IsChatBanListContainsUser = Chat.BlockedUsers.Contains(Banned, userController);

            bool IsUserContainsChat = Banned.PersonalChatList.ListOfChats.Contains(Chat, chatController);
            bool IsUserBlockedListContainsChat = Banned.PersonalChatList.BlockedByChats.Contains(Chat, chatController);

            if (IsChatBanListContainsUser && IsUserBlockedListContainsChat)
            {
                return false;
            }

            if (IsUserContainsChat || IsChatContainsUser)
            {
                LeaveChat(Chat, Banned.UserGUİD);
            }

            Chat.BlockedUsers.Add(Banned);

            if (!((GroupChat)ChatRepository.GetByID(Chat.ChatID)).BlockedUsers.Contains(Banned, userController))
            {
                ChatRepository.UpdateWithPatch(Chat.ChatID, (I) => { ((GroupChat)I).BlockedUsers.Add(Banned); });
            }

            if (!UserRepository.GetByID(Banned.UserGUİD).PersonalChatList.BlockedByChats.Contains(Chat, chatController))
            {
                UserRepository.UpdateWithPatch(Banned.UserGUİD, (I) => { I.PersonalChatList.BlockedByChats.Add(Chat); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);

            return true;
        }

        public bool UnBanUserFromChat(GroupChat Chat, User Banned)
        {
            if (Banned is null || Chat is null)
            {
                return false;
            }

            UserController userController = new UserController();
            ChatController chatController = new ChatController();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            bool IsChatContainsUser = Chat.ChatUsers.Contains(Banned, userController);
            bool IsChatBanListContainsUser = Chat.BlockedUsers.Contains(Banned, userController);

            bool IsUserContainsChat = Banned.PersonalChatList.ListOfChats.Contains(Chat, chatController);
            bool IsUserBlockedListContainsChat = Banned.PersonalChatList.BlockedByChats.Contains(Chat, chatController);

            if (!IsChatBanListContainsUser && !IsUserBlockedListContainsChat)
            {
                return false;
            }

            Chat.BlockedUsers.Remove(Banned, userController);

            if (((GroupChat)ChatRepository.GetByID(Chat.ChatID)).BlockedUsers.Contains(Banned, userController))
            {
                ChatRepository.UpdateWithPatch(Chat.ChatID, (I) => { ((GroupChat)I).BlockedUsers.Remove(Banned, userController); });
            }

            if (UserRepository.GetByID(Banned.UserGUİD).PersonalChatList.BlockedByChats.Contains(Chat, chatController))
            {
                UserRepository.UpdateWithPatch(Banned.UserGUİD, (I) => { I.PersonalChatList.BlockedByChats.Remove(Chat, chatController); });
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);

            return true;
        }

        public bool JoinChat(GroupChat Chat, User User)
        {
            if (Chat is null || User is null)
            {
                return false;
            }

            UserController userController = new();
            ChatController chatController = new();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();


            bool IsChatContainsUser = Chat.ChatUsers.Contains(User, userController);
            bool IsUserContainsChat = User.PersonalChatList.ListOfChats.Contains(Chat, chatController);

            if (IsChatContainsUser && IsUserContainsChat)
            {
                return false;
            }

            if (Chat.BlockedUsers.Contains(User, userController) && User.PersonalChatList.BlockedByChats.Contains(Chat, chatController))
            {
                return false;
            }

            if (!IsChatContainsUser)
            {
                Chat.ChatUsers.Add(User);

                if (!ChatRepository.GetByID(Chat.ChatID).ChatUsers.Contains(User, userController))
                {
                    ChatRepository.UpdateWithPatch(Chat.ChatID, (I) => { I.ChatUsers.Add(User); });
                }
            }

            if (!IsUserContainsChat)
            {
                User.PersonalChatList.ListOfChats.Add(Chat);

                if (!UserRepository.GetByID(User.UserGUİD).PersonalChatList.ListOfChats.Contains(Chat, chatController))
                {
                    UserRepository.UpdateWithPatch(User.UserGUİD, (I) => { I.PersonalChatList.ListOfChats.Add(Chat); });
                }
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            return true;
        }

        public bool LeaveChat(GroupChat Chat, Guid UserID)
        {
            if (Chat is null || UserID == Guid.Empty)
            {
                return false;
            }
            UserController UserController = new();
            ChatController ChatController = new();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            bool IsChatContainsUser = Chat.ChatUsers.Contains(UserRepository.GetByID(UserID), UserController);
            bool IsUserContainsChat = UserRepository.GetByID(UserID).PersonalChatList.ListOfChats.Contains(Chat, ChatController);

            if (!IsChatContainsUser && !IsUserContainsChat)
            {
                return false;
            }
            if (IsChatContainsUser)
            {
                Chat.ChatUsers.Remove(UserRepository.GetByID(UserID), UserController);

                if (ChatRepository.GetByID(Chat.ChatID).ChatUsers.Contains(UserRepository.GetByID(UserID), UserController))
                {
                    ChatRepository.UpdateWithPatch(Chat.ChatID, (I) => { I.ChatUsers.Remove(UserRepository.GetByID(UserID), UserController); });
                }
            }
            if (IsUserContainsChat)
            {
                UserRepository.GetByID(UserID).PersonalChatList.ListOfChats.Remove(Chat, ChatController);
            }

            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            return true;
        }


    }
}
