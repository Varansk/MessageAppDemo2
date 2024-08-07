using MessageAppDemo2.Backend.DataBase.Connections;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RealTimeServicePool
{
    public static class RealTimeMessageServicePool
    {
        private static readonly ObjectPoolsManager<string, RealTimeService<MessageBase>> _RealTimeMessageServicePools;

        static RealTimeMessageServicePool()
        {
            _RealTimeMessageServicePools = new ObjectPoolsManager<string, RealTimeService<MessageBase>>();
        }
        public static void AddRealTimeMessageServicePool(string ID, IObjectPooler<RealTimeService<MessageBase>> Pool)
        {
            _RealTimeMessageServicePools.AddObjectPooler(ID, Pool);
        }
        public static void AddToRealTimeMessageServicePool(this RealTimeService<MessageBase> RealTimeMessageService, string ID)
        {
            ObjectPool<RealTimeService<MessageBase>> pool = new(() => RealTimeMessageService);
            AddRealTimeMessageServicePool(ID, pool);
        }
        public static void RemoveRealTimeMessageServicePool(string ID)
        {
            _RealTimeMessageServicePools.RemoveObjectPooler(ID);
        }
        public static IObjectPooler<RealTimeService<MessageBase>> GetRealTimeMessageServicePool(string ID)
        {
            return _RealTimeMessageServicePools.GetObjectPooler(ID);
        }
    }
}
