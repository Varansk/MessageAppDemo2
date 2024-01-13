﻿using MessageAppDemo.Backend.DataBase.Connections.DataBaseConnections;
using MessageAppDemo.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo.Backend.SystemData.ChangeController;
using MessageAppDemo.Backend.SystemData.CollectionChangeDedector.ChangeDedector;
using MessageAppDemo.Backend.SystemData.ExtensionClasses.CollectionExtensions;
using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.DataBase.Repositorys.AllRepositorys.UserRepository
{

    public class VirtualDatabaseUserRepository : Repository<User, Guid>
    {
        private VirtualDatabase virtualDatabase;
        public VirtualDatabaseUserRepository(VirtualDatabase VDB)
        {
            virtualDatabase = VDB;
            UpdateVirtualList();
        }

        public override User GetByID(Guid ID)
        {
            return _Items.Find(I => I.UserGUİD == ID);
        }

        public override void SaveAllChanges()
        {
            virtualDatabase.OpenConnection();
            ListChangesDedector<User> ChangeDedector = new();

            ChangeInfo<User> ChangeInfo = ChangeDedector.GetChanges(new UserController(), virtualDatabase.UserList, _Items);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    virtualDatabase.UserList.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    virtualDatabase.UserList.RemoveAt(virtualDatabase.UserList.IndexOf(ChangeInfo.RemovedItems[i], new UserController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    virtualDatabase.UserList
                        [virtualDatabase.UserList.IndexOf(ChangeInfo.UpdatedItems[v], new UserController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }


        public override void UpdateVirtualList()
        {
            virtualDatabase.OpenConnection();
            ListChangesDedector<User> ChangeDedector = new();

            ChangeInfo<User> ChangeInfo = ChangeDedector.GetChanges(new UserController(), _Items, virtualDatabase.UserList);

            if (ChangeInfo.IsChanged)
            {
                for (int k = 0; k < ChangeInfo.AddedItems.Count; k++)
                {
                    _Items.Add(ChangeInfo.AddedItems[k]);
                }

                for (int i = 0; i < ChangeInfo.RemovedItems.Count; i++)
                {
                    _Items.RemoveAt(_Items.IndexOf(ChangeInfo.RemovedItems[i], new UserController()));
                }
                for (int v = 0; v < ChangeInfo.UpdatedItems.Count; v++)
                {
                    _Items[ChangeInfo.UpdatedItems.IndexOf(ChangeInfo.UpdatedItems[v], new UserController())] = ChangeInfo.UpdatedItems[v];
                }
            }

            virtualDatabase.CloseConnection();
        }
    }
}
