using System;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.SystemData.ObjectPooler
{
    public class ObjectPoolsManager<ID, TypeofPoolObject> : IObjectPoolsManager<ID, TypeofPoolObject>
    {
        protected readonly Dictionary<ID, IObjectPooler<TypeofPoolObject>> _pools;

        public void AddObjectPooler(ID ID, IObjectPooler<TypeofPoolObject> Pool)
        {
            if (_pools == null)
            {
                throw new ArgumentNullException(nameof(Pool));
            }
            else if (_pools.ContainsKey(ID))
            {
                throw new ArgumentException("This Key Already Exists.");
            }
            _pools.Add(ID, Pool);
        }

        public IObjectPooler<TypeofPoolObject> GetObjectPooler(ID ID)
        {
            return _pools[ID];
        }

        public void RemoveObjectPooler(ID ID)
        {
            _pools.Remove(ID);
        }

        public ObjectPoolsManager()
        {
            _pools = new Dictionary<ID, IObjectPooler<TypeofPoolObject>>();
        }
    }
    interface IObjectPoolsManager<ID, TypeofPoolObject>
    {
        IObjectPooler<TypeofPoolObject> GetObjectPooler(ID ID);
        void AddObjectPooler(ID ID, IObjectPooler<TypeofPoolObject> Pool);
        void RemoveObjectPooler(ID ID);
    }
}
