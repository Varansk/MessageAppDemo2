using MessageAppDemo.Backend.SystemData.ChangeController.Interfaces;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.SystemData.CollectionChangeDedector.ChangeDedector.Interfaces
{
    public interface ICollectionChangeDedector<ItemType>
    {
        ChangeInfo<ItemType> GetChanges(BaseController<ItemType> Controller, in List<ItemType> OldList, in List<ItemType> UpdatedList);
    }
}
