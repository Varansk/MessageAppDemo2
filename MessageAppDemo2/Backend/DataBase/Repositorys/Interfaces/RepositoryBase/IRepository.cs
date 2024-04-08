using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces.RepositoryBase
{
    public interface IRepository<Item, ID> where Item : class
    {
        void Add(Item Item);
        void Remove(ID ID);
        void Remove(Item Item, BaseController<Item> Controller);
        void UpdateWithPut(ID ID, Item Model);
        void UpdateWithPut(Item Item, Item Model, BaseController<Item> Controller);
        void UpdateWithPatch(ID ID, Action<Item> ChangestoBeMade);
        void UpdateWithPatch(Item Item, Action<Item> ChangesToBeMade, BaseController<Item> Controller);

        Item GetByID(ID ID);
        List<Item> GetAll();
        List<Item> GetWhere(Func<Item, bool> Predicate);
        Item GetSingle(Predicate<Item> Predicate);

        void SaveAllChanges();
        void UpdateVirtualList();
    }
}
