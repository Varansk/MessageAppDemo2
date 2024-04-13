using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.ReportSystem.Interfaces;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools
{
    public static class DatabaseReportRepositoryPools
    {
        private static readonly ObjectPoolsManager<string, DatabaseRepository<ReportBase, Guid>> _DatabaseRepositoryPools;

        static DatabaseReportRepositoryPools()
        {
            _DatabaseRepositoryPools = new ObjectPoolsManager<string, DatabaseRepository<ReportBase, Guid>>();
        }
        public static void AddDatabaseReportRepositoryPool(string ID, IObjectPooler<DatabaseRepository<ReportBase, Guid>> Pool)
        {
            _DatabaseRepositoryPools.AddObjectPooler(ID, Pool);
        }
        public static void AddToDatabaseReportRepositoryPool(this DatabaseRepository<ReportBase, Guid> DatabaseRepository, string ID)
        {
            ObjectPool<DatabaseRepository<ReportBase, Guid>> pool = new(() => DatabaseRepository);
            AddDatabaseReportRepositoryPool(ID, pool);
        }
        public static void RemoveDatabaseReportRepositoryPool(string ID)
        {
            _DatabaseRepositoryPools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<DatabaseRepository<ReportBase, Guid>> GetDatabaseReportRepositoryPool(string ID)
        {
            return _DatabaseRepositoryPools.GetObjectPooler(ID);
        }
    }
}
