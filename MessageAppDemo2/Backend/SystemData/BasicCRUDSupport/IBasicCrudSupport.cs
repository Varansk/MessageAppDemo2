using System;

namespace MessageAppDemo2.Backend.SystemData.BasicCRUDSupport
{
    public interface IBasicCrudSupport<Item,  ID>
    {
        void Add(Item Item);
        void Remove(ID ID);
        void Update(ID ID, Action<Item> Changes);
        Item GetByID(ID ID);
    }
}
