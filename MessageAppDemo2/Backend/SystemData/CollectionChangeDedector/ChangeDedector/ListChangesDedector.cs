using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using MessageAppDemo2.Backend.SystemData.CollectionChangeDedector.ChangeDedector.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo2.Backend.SystemData.CollectionChangeDedector.ChangeDedector
{
    public class ListChangesDedector<ItemType> : ICollectionChangeDedector<ItemType>
    {
        public ChangeInfo<ItemType> GetChanges(BaseController<ItemType> Controller, in List<ItemType> OldList,
            in List<ItemType> UpdatedList)
        {
            List<ItemType> AddedItems = new List<ItemType>();
            List<ItemType> RemovedItems = new List<ItemType>();
            List<ItemType> UpdatedItems = new List<ItemType>();

            List<ItemType> NewOldList = OldList.ToList();
            List<ItemType> NewUpdatedList = UpdatedList.ToList();

            for (int i = 0; i < NewUpdatedList.Count; i++)
            {
                for (int j = 0; j < NewOldList.Count; j++)
                {
                    if (Controller.UpdateController.Invoke(NewUpdatedList[i], NewOldList[j]))
                    {
                        UpdatedItems.Add(NewUpdatedList[j]);

                        NewOldList.RemoveAt(j);
                        NewUpdatedList.RemoveAt(i);
                        --i;
                        break;
                    }
                    else if (Controller.AddRemoveController.Invoke(NewUpdatedList[i], NewOldList[j]))
                    {
                        NewOldList.RemoveAt(j);
                        NewUpdatedList.RemoveAt(i);
                        --i;
                        break;
                    }
                }
            }

            AddedItems.AddRange(NewUpdatedList);
            RemovedItems.AddRange(NewOldList);

            ChangeInfo<ItemType> Changes = new ChangeInfo<ItemType>()
            {
                UpdatedItems = UpdatedItems,
                AddedItems = AddedItems,
                RemovedItems = RemovedItems,
                IsChanged = UpdatedItems.Any() || AddedItems.Any() || RemovedItems.Any()
            };

            return Changes;
        }
    }
}
