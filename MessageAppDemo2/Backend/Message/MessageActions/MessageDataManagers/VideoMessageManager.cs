﻿using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.DataBase.Repositorys.RepositoryExtensions;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using System;

namespace MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers
{
    public class VideoMessageManager : IMessageManager<VideoMessage, int>
    {
        private Guid _DependentChatID;
        private string _Route;
        public Guid DependentGuid
        {
            get
            {
                return _DependentChatID;
            }
            set
            {
                _DependentChatID = value;
            }
        }

        public string Route { get { return _Route; } set { _Route = value; } }

        public void Add(VideoMessage Item)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            MessageRepository.SetDependentChat(Item.DependentChatGuid);
            MessageRepository.SetRoute(Item.ChatRoute);


            MessageRepository.Add(Item);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(MessageRepository);
        }

        public VideoMessage GetByID(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageBase Message = MessageRepository.GetByID(ID);

            DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(MessageRepository);

            return Message as VideoMessage;
        }

        public void Remove(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageRepository.Remove(MessageRepository.GetByID(ID), new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(MessageRepository);
        }

        public void Update(int ID, Action<VideoMessage> Changes)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageRepository.UpdateWithPatch(MessageRepository.GetByID(ID), Changes as Action<MessageBase>, new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(MessageRepository);
        }
    }
}
