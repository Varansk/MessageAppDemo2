using MessageAppDemo.Backend.Chatting.ChatActions.ChatManagers.Interfaces;
using MessageAppDemo.Backend.Chatting.ChatData;
using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Chatting.ChatUserActions;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo.Backend.DataBase.Repositorys;
using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.Chatting.ChatActions.ChatManagers
{
    public class GroupChatManager : IChatManager<GroupChat, Guid>
    {
        public void Add(GroupChat Item)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            ChatRepository.Add(Item);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
        }

        public GroupChat GetByID(Guid ID)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            GroupChat Chat = ChatRepository.GetByID(ID) as GroupChat;

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);

            return Chat;
        }

        public void Remove(Guid ID)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            GroupChatUserManager GroupChatUserManager = new();

            GroupChat Chat = ChatRepository.GetByID(ID) as GroupChat;

            if (Chat == null)
            {
                return;
            }

            foreach (User item in Chat.ChatUsers)
            {
                UserRepository.UpdateWithPatch(item.UserGUİD, I =>
                {
                    GroupChatUserManager.LeaveChat(Chat, item.UserGUİD);
                });
            }

            ChatRepository.Remove(ID);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }

        public void Update(Guid ID, Action<GroupChat> Changes)
        {
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();
            DatabaseRepository<User, Guid> UserRepository = DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            ChatRepository.UpdateWithPatch(ID, I =>
            {
                Changes.Invoke(I as GroupChat);
            });

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseUserRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(UserRepository);
        }
    }
}
