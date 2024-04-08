using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase
{
    public abstract class Repository<Item, ID> : IRepository<Item, ID> where Item : class
    {
        protected List<Item> _Items;

        public Repository()
        {
            _Items = new List<Item>();
        }
        public void Add(Item Item)
        {
            _Items.Add(Item);
        }
        public void Remove(ID ID)
        {
            int Index = _Items.IndexOf(GetByID(ID));

            if (Index != -1)
            {
                _Items.RemoveAt(Index);
            }

        }
        public void Remove(Item Item, BaseController<Item> Controller)
        {
            foreach (Item item in _Items)
            {
                if (Controller.AddRemoveController.Invoke(item, Item) && !Controller.UpdateController.Invoke(Item, item))
                {
                    _Items.Remove(item);
                }
            }
        }
        public void UpdateWithPatch(ID ID, Action<Item> ChangestoBeMade)
        {
            int Index = _Items.IndexOf(GetByID(ID));

            if (Index != -1)
            {
                ChangestoBeMade.Invoke(_Items[Index]);
            }
        }
        public void UpdateWithPatch(Item Item, Action<Item> ChangesToBeMade, BaseController<Item> Controller)
        {
            foreach (Item item in _Items)
            {
                if (Controller.AddRemoveController.Invoke(item, Item) && !Controller.UpdateController.Invoke(Item, item))
                {
                    ChangesToBeMade.Invoke(item);
                    if (Item != item)
                    {
                        ChangesToBeMade.Invoke(Item);
                    }             
                }
            }
        }

        public void UpdateWithPut(ID ID, Item Model)
        {
            int Index = _Items.IndexOf(GetByID(ID));

            if (Index != -1)
            {
                _Items[Index] = Model;
            }
        }
        public void UpdateWithPut(Item Item, Item Model, BaseController<Item> Controller)
        {
            for (int i = 0; i < _Items.Count; i++)
            {
                if (Controller.AddRemoveController.Invoke(_Items[i], Item) && !Controller.UpdateController.Invoke(Item, _Items[i]))
                {
                    _Items[i] = Model;
                    Item = Model;
                }
            }
        }

        public List<Item> GetAll()
        {
            return _Items.ToList();
        }
        public Item GetSingle(Predicate<Item> Predicate)
        {
            return _Items.Find(Predicate);
        }

        public List<Item> GetWhere(Func<Item, bool> Predicate)
        {
            return _Items.Where(Predicate).ToList();
        }

        public abstract Item GetByID(ID ID);
        public abstract void SaveAllChanges();
        public abstract void UpdateVirtualList();

    }
}
