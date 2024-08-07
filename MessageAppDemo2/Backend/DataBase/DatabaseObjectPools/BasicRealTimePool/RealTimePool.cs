using MessageAppDemo2.Backend.DataBase.Connections;
using MessageAppDemo2.Backend.DataBase.RealTimeConneciton;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.BasicRealTimePool
{
    public static class RealTimePool
    {
        private static readonly ObjectPoolsManager<string, RealTimeConnect> _RealTimePools;

        static RealTimePool()
        {
            _RealTimePools = new ObjectPoolsManager<string, RealTimeConnect>();
        }
        public static void AddRealTimePool(string ID, IObjectPooler<RealTimeConnect> Pool)
        {
            _RealTimePools.AddObjectPooler(ID, Pool);
        }
        public static void AddRealTimePool(this RealTimeConnect DatabaseValue, string ID)
        {
            ObjectPool<RealTimeConnect> ObjectPool = new(() => DatabaseValue);
            AddRealTimePool(ID, ObjectPool);
        }
        public static void RemoveTimePool(string ID)
        {
            _RealTimePools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<RealTimeConnect> GetRealTimePool(string ID)
        {
            return _RealTimePools.GetObjectPooler(ID);
        }
    }
}
