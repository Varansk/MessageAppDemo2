using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System.Collections.Generic;
using System;
using System.Windows.Documents;
using MessageAppDemo2.Backend.Chatting.ChatUserActions.Factory;
using System.Linq;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Users.UserUserManager.Interfaces;
using System.Reflection;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions
{
    public class ChatUserManager
    {
        public bool JoinChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, User User) where ChatType : ChatBase
        {
            return ChatUserManager.JoinChat(Chat, User);
        }
        public bool LeaveChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, UserIDType ID) where ChatType : ChatBase
        {
            return ChatUserManager.LeaveChat(Chat, ID);
        }
        public bool BanUserFromChat<UserIDType, ChatType>(IBannableChatUserManager<UserIDType, ChatType> BannableChatUserManager, ChatType Chat, User Banned) where ChatType : ChatBase
        {
            return BannableChatUserManager.BanUserFromChat(Chat, Banned);
        }
        public bool UnBanUserFromChat<UserIDType, ChatType>(IBannableChatUserManager<UserIDType, ChatType> BannableChatUserManager, ChatType Chat, User Banned) where ChatType : ChatBase
        {
            return BannableChatUserManager.UnBanUserFromChat(Chat, Banned);
        }
        public bool LeaveAllChats(User User)
        {
            DatabaseRepository<User, Guid> databaseRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            User = databaseRepository.GetByID(User.UserGUİD);

            if (User.PersonalChatList.ListOfChats.Count == 0)
            {
                return false;
            }
            ChatUserManagerFactory chatUserManagerFactory = new ChatUserManagerFactory();

            Dictionary<ChatType, List<ChatBase>> keyValuePairs = new Dictionary<ChatType, List<ChatBase>>();


            foreach (var chat in User.PersonalChatList.ListOfChats)
            {
                if (keyValuePairs.Keys.Contains((ChatType)chat))
                {
                    keyValuePairs[(ChatType)chat].Add(chat);
                }
                else
                {
                    keyValuePairs.Add((ChatType)chat, new List<ChatBase>() { chat });
                }
            }
            
            foreach (ChatType key in keyValuePairs.Keys)
            {
                List<ChatBase> chats = keyValuePairs[key];

                dynamic chatuserManager = chatUserManagerFactory.CreateInstance(key);

                chats.ForEach((I) =>
                {

                    Type type = chatuserManager.GetType();

                    MethodInfo m = typeof(ChatUserManager).GetMethod("LeaveChat").MakeGenericMethod(type.GetInterface("IChatUserManager`2").GenericTypeArguments[0], type.GetInterface("IChatUserManager`2").GenericTypeArguments[1]);

                    m.Invoke(this, new object[] { chatuserManager, I, User.UserGUİD });
                });

            }
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(databaseRepository);
            return true;
        }

    }
}


