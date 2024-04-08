using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools
{
    public static class DatabaseMessageRepositoryPools
    {
        private static readonly ObjectPoolsManager<string, DatabaseRepository<MessageBase, int>> _DatabaseRepositoryPools;

        static DatabaseMessageRepositoryPools()
        {
            _DatabaseRepositoryPools = new ObjectPoolsManager<string, DatabaseRepository<MessageBase, int>>();
        }
        public static void AddDatabaseMessageRepositoryPool(string ID, IObjectPooler<DatabaseRepository<MessageBase, int>> Pool)
        {
            _DatabaseRepositoryPools.AddObjectPooler(ID, Pool);
        }
        public static void AddToDatabaseMessageRepositoryPool(this DatabaseRepository<MessageBase, int> DatabaseRepository, string ID)
        {
            ObjectPool<DatabaseRepository<MessageBase, int>> pool = new(() => DatabaseRepository);
            AddDatabaseMessageRepositoryPool(ID, pool);
        }
        public static void RemoveDatabaseMessageRepositoryPool(string ID)
        {
            _DatabaseRepositoryPools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<DatabaseRepository<MessageBase, int>> GetDatabaseUserRepositoryPool(string ID)
        {
            return _DatabaseRepositoryPools.GetObjectPooler(ID);
        }
    }
}
