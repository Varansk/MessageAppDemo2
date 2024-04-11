using System;

namespace MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces
{
    public abstract class BaseController<Item>
    {
        /// <summary>
        /// Controls Items ID is Equal
        /// </summary>
        public abstract Func<Item, Item, bool> AddRemoveController { get; }

        
        /// <summary>
        /// Controls Items ID is Equal and at Least One of Element is Different
        /// </summary>
        public abstract Func<Item, Item, bool> UpdateController { get; }
    }
}
