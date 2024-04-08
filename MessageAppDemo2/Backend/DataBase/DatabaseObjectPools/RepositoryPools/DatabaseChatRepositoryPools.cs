using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using System;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools
{
    public static class DatabaseChatRepositoryPools
    {
        private static readonly ObjectPoolsManager<string, DatabaseRepository<ChatBase, Guid>> _DatabaseRepositoryPools;

        static DatabaseChatRepositoryPools()
        {
            _DatabaseRepositoryPools = new ObjectPoolsManager<string, DatabaseRepository<ChatBase, Guid>>();
        }
        public static void AddDatabaseChatRepositoryPool(string ID, IObjectPooler<DatabaseRepository<ChatBase, Guid>> Pool)
        {
            _DatabaseRepositoryPools.AddObjectPooler(ID, Pool);
        }
        public static void AddToDatabaseChatRepositoryPool(this DatabaseRepository<ChatBase, Guid> DatabaseRepository, string ID)
        {
            ObjectPool<DatabaseRepository<ChatBase, Guid>> pool = new(() => DatabaseRepository);
            AddDatabaseChatRepositoryPool(ID, pool);
        }
        public static void RemoveDatabaseChatRepositoryPool(string ID)
        {
            _DatabaseRepositoryPools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<DatabaseRepository<ChatBase, Guid>> GetDatabaseChatRepositoryPool(string ID)
        {
            return _DatabaseRepositoryPools.GetObjectPooler(ID);
        }
    }
}
