using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ChangeController;
using MessageAppDemo2.Backend.SystemData.CollectionChangeDedector.ChangeDedector;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using System;
using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
namespace MessageAppDemo2.Backend.DataBase.Repositorys.AllRepositorys.MessageRepository
{
    public class VirtualDatabaseMessageRepository : Repository<MessageBase, int>, IChatSelector
    {
        private VirtualDatabase virtualDatabase;
        private ChatBase dependentChat;
        public VirtualDatabaseMessageRepository(VirtualDatabase VDB, ChatBase DependentChat)
        {
            virtualDatabase = VDB;
            dependentChat = DependentChat;
            UpdateVirtualList();
        }
        public void SetDependentChat(ChatBase Chat)
        {
            dependentChat = Chat;
        }


        public override MessageBase GetByID(int ID)
        {
            return _Items.Find(I => I.MessageID == ID && I.WhichChatMessageSent.ChatID == dependentChat.ChatID);
        }

        public override void SaveAllChanges()
        {
            virtualDatabase.OpenConnection();

            ListChangesDedector<MessageBase> ChangeDedector = new();

            ChangeInfo<MessageBase> ChangeInfo = ChangeDedector.GetChanges(new MessageController(), virtualDatabase.MessageList, _Items);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    virtualDatabase.MessageList.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    virtualDatabase.MessageList.RemoveAt(virtualDatabase.MessageList.IndexOf(ChangeInfo.RemovedItems[i], new MessageController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    virtualDatabase.MessageList
                        [virtualDatabase.MessageList.IndexOf(ChangeInfo.UpdatedItems[v], new MessageController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }

        public override void UpdateVirtualList()
        {
            virtualDatabase.OpenConnection();
            ListChangesDedector<MessageBase> ChangeDedector = new();

            ChangeInfo<MessageBase> ChangeInfo = ChangeDedector.GetChanges(new MessageController(), _Items, virtualDatabase.MessageList);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    _Items.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    _Items.RemoveAt(_Items.IndexOf(ChangeInfo.RemovedItems[i], new MessageController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    _Items[ChangeInfo.UpdatedItems.IndexOf(ChangeInfo.UpdatedItems[v], new MessageController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }
    }
}
