using MessageAppDemo.Backend.DataBase.Repositorys.Interfaces.RepositoryBase;
using MessageAppDemo.Backend.SystemData.ChangeController.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.DataBase.Repositorys
{
    public class DatabaseRepository<Item, ID> where Item : class
    {
        private Repository<Item, ID> _Repository;

        public DatabaseRepository()
        {

        }
        public DatabaseRepository(Repository<Item, ID> Repository)
        {
            GeneralRepository = Repository;
        }
        public Repository<Item, ID> GeneralRepository { get => _Repository; set => _Repository = value; }

        public void Add(Item Item)
        {
            _Repository.UpdateVirtualList();
            _Repository.Add(Item);
            _Repository.SaveAllChanges();
        }
        public List<Item> GetAll()
        {
            _Repository.UpdateVirtualList();
            return _Repository.GetAll();
        }
        public Item GetByID(ID ID)
        {
            _Repository.UpdateVirtualList();
            return _Repository.GetByID(ID);
        }
        public Item GetSingle(Predicate<Item> Predicate)
        {
            _Repository.UpdateVirtualList();
            return _Repository.GetSingle(Predicate);
        }
        public List<Item> GetWhere(Func<Item, bool> Predicate)
        {
            _Repository.UpdateVirtualList();
            return _Repository.GetWhere(Predicate);
        }
        public void Remove(ID ID)
        {
            _Repository.UpdateVirtualList();
            _Repository.Remove(ID);
            _Repository.SaveAllChanges();
        }
        public void Remove(Item Item, BaseController<Item> Controller)
        {
            _Repository.UpdateVirtualList();
            _Repository.Remove(Item, Controller);
            _Repository.SaveAllChanges();
        }
        public void SaveAllChanges()
        {
            _Repository.SaveAllChanges();
        }
        public void UpdateVirtualList()
        {
            _Repository.UpdateVirtualList();
        }
        public void UpdateWithPatch(ID ID, Action<Item> ChangestoBeMade)
        {
            _Repository.UpdateVirtualList();
            _Repository.UpdateWithPatch(ID, ChangestoBeMade);
            _Repository.SaveAllChanges();
        }
        public void UpdateWithPatch(Item Item, Action<Item> ChangestoBeMade, BaseController<Item> Controller)
        {
            _Repository.UpdateVirtualList();
            _Repository.UpdateWithPatch(Item, ChangestoBeMade, Controller);
            _Repository.SaveAllChanges();
        }
        public void UpdateWithPut(ID ID, Item Model)
        {
            _Repository.UpdateVirtualList();
            _Repository.UpdateWithPut(ID, Model);
            _Repository.SaveAllChanges();
        }
        public void UpdateWithPut(Item Item, Item Model, BaseController<Item> Controller)
        {
            _Repository.UpdateVirtualList();
            _Repository.UpdateWithPut(Item, Model, Controller);
            _Repository.SaveAllChanges();
        }

    }
}
