using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.SystemData.CollectionChangeDedector.ChangeDedector.Interfaces
{
    public interface ICollectionChangeDedector<ItemType>
    {
        ChangeInfo<ItemType> GetChanges(BaseController<ItemType> Controller, in List<ItemType> OldList, in List<ItemType> UpdatedList);
    }
}
