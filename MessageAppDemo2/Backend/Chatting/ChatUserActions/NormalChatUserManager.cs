using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ChangeController.SubControllers;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions
{
    public class NormalChatUserManager : IChatUserManager<Guid, NormalChat>
    {
        public bool JoinChat(NormalChat Chat, User User)
        {
            /*if (Chat is null || User is null)
            {
                return false;
            }
            bool IsChatContainsUser = Chat.ChatUsers.Contains(User, new UserController());
            bool IsUserContainsChat = User.PersonalChatList.ListOfChats.Contains(Chat, new ChatController());

            if (IsChatContainsUser && IsUserContainsChat)
            {
                return false;
            }
            if (!IsChatContainsUser)
            {
                Chat.ChatUsers.Add(User);
            }
            if (!IsUserContainsChat)
            {
                User.PersonalChatList.ListOfChats.Add(Chat);
            }
            return true;*/

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

        public bool LeaveChat(NormalChat Chat, Guid UserID)
        {
            /*if (Chat is null || UserID == Guid.Empty)
            {
                return false;
            }
            UserController UserController = new();
            ChatController ChatController = new();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User User = UserRepository.GetByID(UserID);


            bool IsChatContainsUser = Chat.ChatUsers.Contains(User, new UserController());
            bool IsUserContainsChat = User.PersonalChatList.ListOfChats.Contains(Chat, new ChatController());

            if (!IsChatContainsUser && !IsUserContainsChat)
            {
                return false;
            }
            if (IsChatContainsUser)
            {
                Chat.ChatUsers.Remove(User, new UserController());
            }
            if (IsUserContainsChat)
            {
                User.PersonalChatList.ListOfChats.Remove(Chat, ChatController);
            }
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
            return true;*/

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
