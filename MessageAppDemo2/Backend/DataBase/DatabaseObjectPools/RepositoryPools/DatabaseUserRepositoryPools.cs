﻿using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools
{
    public static class DatabaseUserRepositoryPools
    {
        private static readonly ObjectPoolsManager<string, DatabaseRepository<User, Guid>> _DatabaseRepositoryPools;

        static DatabaseUserRepositoryPools()
        {
            _DatabaseRepositoryPools = new ObjectPoolsManager<string, DatabaseRepository<User, Guid>>();
        }
        public static void AddDatabaseUserRepositoryPool(string ID, IObjectPooler<DatabaseRepository<User, Guid>> Pool)
        {
            _DatabaseRepositoryPools.AddObjectPooler(ID, Pool);
        }
        public static void AddToDatabaseUserRepositoryPool(this DatabaseRepository<User, Guid> DatabaseRepository, string ID)
        {
            ObjectPool<DatabaseRepository<User, Guid>> pool = new(() => DatabaseRepository);
            AddDatabaseUserRepositoryPool(ID, pool);
        }
        public static void RemoveDatabaseUserRepositoryPool(string ID)
        {
            _DatabaseRepositoryPools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<DatabaseRepository<User, Guid>> GetDatabaseUserRepositoryPool(string ID)
        {
            return _DatabaseRepositoryPools.GetObjectPooler(ID);
        }

    }
}
