using MessageAppDemo.Backend.Chatting.ChatData;
using MessageAppDemo.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo.Backend.DataBase.Repositorys;
using MessageAppDemo.Backend.SystemData.ChangeController;
using MessageAppDemo.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo.Backend.Chatting.ChatUserActions
{
    public class NormalChatUserManager : IChatUserManager<Guid, NormalChat>
    {
        public bool JoinChat(NormalChat Chat, User User)
        {
            if ((Chat is null || User is null))
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
            return true;

        }

        public bool LeaveChat(NormalChat Chat, Guid UserID)
        {
            if (Chat is null || UserID == Guid.Empty)
            {
                return false;
            }
            UserController UserController = new();
            ChatController ChatController = new();

            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User User = UserRepository.GetByID(UserID);
            

            bool IsChatContainsUser = Chat.ChatUsers.Contains(User, new UserController());
            bool IsUserContainsChat = User.PersonalChatList.ListOfChats.Contains(Chat, new ChatController());

            if(!IsChatContainsUser && !IsUserContainsChat)
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
            return true;
        }
    }
}
