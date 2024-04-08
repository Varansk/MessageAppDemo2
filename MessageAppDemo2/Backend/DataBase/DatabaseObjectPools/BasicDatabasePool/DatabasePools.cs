using MessageAppDemo2.Backend.DataBase.Connections;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.BasicDatabasePool
{
    public static class DatabasePools
    {
        private static readonly ObjectPoolsManager<string, DataBaseConnect> _DatabasePools;

        static DatabasePools()
        {
            _DatabasePools = new ObjectPoolsManager<string, DataBaseConnect>();
        }
        public static void AddDatabasePool(string ID, IObjectPooler<DataBaseConnect> Pool)
        {
            _DatabasePools.AddObjectPooler(ID, Pool);
        }
        public static void AddToDatabasePool(this DataBaseConnect DatabaseValue, string ID)
        {
            ObjectPool<DataBaseConnect> ObjectPool = new(() => DatabaseValue);

        }
        public static void RemoveDatabasePool(string ID)
        {
            _DatabasePools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<DataBaseConnect> GetDatabasePool(string ID)
        {
            return _DatabasePools.GetObjectPooler(ID);
        }

    }
}
