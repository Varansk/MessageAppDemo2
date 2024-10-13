using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
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
    public class VoiceMessageManager : IMessageManager<VoiceMessage, int>
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

        public void Add(VoiceMessage Item)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

            MessageRepository.SetDependentChat(Item.DependentChatGuid);
            MessageRepository.SetRoute(Item.ChatRoute);

            Item.DependentChatGuid = _DependentChatID;

            MessageRepository.Add(Item);
            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public VoiceMessage GetByID(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageBase Message = MessageRepository.GetByID(ID);

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);

            return Message as VoiceMessage;
        }

        public void Remove(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageRepository.Remove(MessageRepository.GetByID(ID), new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public void Update(int ID, Action<VoiceMessage> Changes)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageRepository.UpdateWithPatch(MessageRepository.GetByID(ID), Changes as Action<MessageBase>, new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }
    }
}
