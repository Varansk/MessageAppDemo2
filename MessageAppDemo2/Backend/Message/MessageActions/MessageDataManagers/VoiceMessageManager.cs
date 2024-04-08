using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using System;

namespace MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers
{
    public class VoiceMessageManager : IMessageManager<VoiceMessage, int>
    {
        private Guid _DependentChatID;
        public ChatBase DependentChat
        {
            get
            {
                DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

                ChatBase chat = ChatRepository.GetByID(_DependentChatID);

                DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);

                return chat;
            }
            set
            {
                _DependentChatID = value.ChatID;
            }
        }

        public void Add(VoiceMessage Item)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            ChatRepository.UpdateWithPatch(_DependentChatID, I => I.Messages.Add(Item));
            MessageRepository.Add(Item);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public VoiceMessage GetByID(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageBase Message = MessageRepository.GetSingle(I => I.MessageID == ID && I.WhichChatMessageSent.ChatID == _DependentChatID);

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);

            return Message as VoiceMessage;
        }

        public void Remove(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageRepository.Remove(MessageRepository.GetSingle(I => I.WhichChatMessageSent.ChatID == _DependentChatID && I.MessageID == ID), new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public void Update(int ID, Action<VoiceMessage> Changes)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageRepository.UpdateWithPatch(MessageRepository.GetSingle(I => I.MessageID == ID), Changes as Action<MessageBase>, new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }
    }
}
