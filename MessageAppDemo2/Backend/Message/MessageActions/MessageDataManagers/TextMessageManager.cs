﻿using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo.Backend.DataBase.Repositorys;
using MessageAppDemo.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.SystemData.ChangeController;
using System;

namespace MessageAppDemo.Backend.Message.MessageActions.MessageDataManagers
{
    public class TextMessageManager : IMessageManager<TextMessage, int>
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

        public void Add(TextMessage Item)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            ChatRepository.UpdateWithPatch(_DependentChatID, I => I.Messages.Add(Item));
            MessageRepository.Add(Item);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public TextMessage GetByID(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageBase Message = MessageRepository.GetSingle(I => I.MessageID == ID && I.WhichChatMessageSent.ChatID == _DependentChatID);

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);

            return Message as TextMessage;
        }

        public void Remove(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageRepository.Remove(MessageRepository.GetSingle(I => I.WhichChatMessageSent.ChatID == _DependentChatID && I.MessageID == ID), new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public void Update(int ID, Action<TextMessage> Changes)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageRepository.UpdateWithPatch(MessageRepository.GetSingle(I => I.MessageID == ID), Changes as Action<MessageBase>, new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }
    }
}