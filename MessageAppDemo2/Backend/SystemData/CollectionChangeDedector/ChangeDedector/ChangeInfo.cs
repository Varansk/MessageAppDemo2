using System.Collections.Generic;

namespace MessageAppDemo.Backend.SystemData.CollectionChangeDedector.ChangeDedector
{
    public record class ChangeInfo<ItemType>
    {
        public List<ItemType> AddedItems { get; init; }
        public List<ItemType> RemovedItems { get; init; }
        public List<ItemType> UpdatedItems { get; init; }
        public bool IsChanged { get; init; }
    }
}
