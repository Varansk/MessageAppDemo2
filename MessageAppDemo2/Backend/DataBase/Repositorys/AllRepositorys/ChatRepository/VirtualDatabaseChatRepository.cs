﻿using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo.Backend.SystemData.ChangeController;
using MessageAppDemo.Backend.SystemData.CollectionChangeDedector.ChangeDedector;
using MessageAppDemo.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using System;

namespace MessageAppDemo.Backend.DataBase.Repositorys.AllRepositorys.ChatRepository
{
    public class VirtualDatabaseChatRepository : Repository<ChatBase, Guid>
    {
        private VirtualDatabase virtualDatabase;
        public VirtualDatabaseChatRepository(VirtualDatabase Database)
        {
            virtualDatabase = Database;
            UpdateVirtualList();
        }
        public override ChatBase GetByID(Guid ID)
        {
            return _Items.Find(I => I.ChatID == ID);
        }

        public override void SaveAllChanges()
        {
            virtualDatabase.OpenConnection();
            ListChangesDedector<ChatBase> ChangeDedector = new();

            ChangeInfo<ChatBase> ChangeInfo = ChangeDedector.GetChanges(new ChatController(), virtualDatabase.ChatList, _Items);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    virtualDatabase.ChatList.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    virtualDatabase.ChatList.
                        RemoveAt(virtualDatabase.ChatList.IndexOf(ChangeInfo.RemovedItems[i], new ChatController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    virtualDatabase.ChatList
                        [virtualDatabase.ChatList.IndexOf(ChangeInfo.UpdatedItems[v], new ChatController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }

        public override void UpdateVirtualList()
        {
            virtualDatabase.OpenConnection();
            ListChangesDedector<ChatBase> ChangeDedector = new();

            ChangeInfo<ChatBase> ChangeInfo = ChangeDedector.GetChanges(new ChatController(), _Items, virtualDatabase.ChatList);

            if (ChangeInfo.IsChanged)
            {
                for(int k = 0;k < ChangeInfo.AddedItems.Count;k++)
                {
                    _Items.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    _Items.RemoveAt(_Items.IndexOf(ChangeInfo.RemovedItems[i], new ChatController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    _Items[ChangeInfo.UpdatedItems.IndexOf(ChangeInfo.UpdatedItems[v], new ChatController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }
    }
}
