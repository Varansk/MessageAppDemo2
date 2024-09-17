using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.DataBase.Repositorys.RepositoryExtensions;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using System;
using System.Windows.Navigation;

namespace MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers
{
    public class TextMessageManager : IMessageManager<TextMessage, int>
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

        public void Add(TextMessage Item)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            MessageRepository.SetDependentChat(Item.DependentChatGuid);
            MessageRepository.SetRoute(Item.ChatRoute);

            ChatRepository.UpdateWithPatch(_DependentChatID, I => I.Messages.Add(Item));
            MessageRepository.Add(Item);

            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public TextMessage GetByID(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageBase Message = MessageRepository.GetByID(ID);
            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);

            return Message as TextMessage;
        }

        public void Remove(int ID)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);


            MessageRepository.Remove(MessageRepository.GetByID(ID), new MessageController());

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
        }

        public void Update(int ID, Action<TextMessage> Changes)
        {
            DatabaseRepository<MessageBase, int> MessageRepository = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            DatabaseRepository<ChatBase, Guid> ChatRepository = DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Get();

            MessageRepository.SetDependentChat(_DependentChatID);
            MessageRepository.SetRoute(Route);

            MessageRepository.UpdateWithPatch(MessageRepository.GetByID(ID), Changes as Action<MessageBase>, new MessageController());
            ChatRepository.GetByID(_DependentChatID).Messages.Remove(MessageRepository.GetByID(ID), new MessageController());



            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(MessageRepository);
            DatabaseChatRepositoryPools.GetDatabaseChatRepositoryPool("DTBR").Return(ChatRepository);
        }
    }
}
