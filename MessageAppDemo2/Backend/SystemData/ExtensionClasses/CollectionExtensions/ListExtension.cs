using MessageAppDemo2.Backend.SystemData.ChangeController.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Checks whether the object exists according to the controller object. 
        /// </summary>
        /// <returns>If it is in the list, it returns true, if not, it returns false.</returns>
        public static bool Contains<T>(this List<T> value, T Value, BaseController<T> Controller)
        {
            return value.IndexOf(Value, Controller) != -1;
        }
        /// <summary>
        /// Returns the index of the given object according to the controller. Returns -1 if not found.
        /// </summary>
        public static int IndexOf<T>(this List<T> value, T Value, BaseController<T> Controller)
        {
            if (Value is null || value.Count == 0)
            {
                return -1;
            }
            for (int i = 0; i < value.Count; i++)
            {
                if (Controller.AddRemoveController.Invoke(value[i], Value))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Clones the list with objects derived from IClonable.
        /// </summary>
        public static List<T> Clone<T>(this List<T> value) where T : class, ICloneable
        {
            List<T> ClonedList = new();

            foreach (T item in value)
            {
                ClonedList.Add(item.Clone() as T);
                // ClonedList.Add(DeepCloner.DeepCloner.DeepClone(item));
            };

            return ClonedList;
        }
        /// <summary>
        /// Checks whether all elements of the list are the same.
        /// </summary>
        public static bool ContainsSameElements<T>(this List<T> value, List<T> ListToCompare)
        {
            return value.All(ListToCompare.Contains) && value.Count == ListToCompare.Count;
        }
        /// <summary>
        /// It checks whether it contains exactly the same elements according to the controller.
        /// </summary>
        public static bool ContainsSameElements<T>(this List<T> value, List<T> ListToCompare, BaseController<T> Controller)
        {
            return value.All(I => ListToCompare.Contains(I, Controller)) && value.Count == ListToCompare.Count;
        }
        /// <summary>
        /// Checks the given object against the controller and removes it from the list.
        /// </summary>
        /// <returns>Returns true if successfully deleted, false if not.</returns>
        public static bool Remove<T>(this List<T> value, T Item, BaseController<T> Controller)
        {
            int valueCount = value.Count;

            value.RemoveAt(value.IndexOf(Item, Controller));
            if (value.Count == valueCount - 1)
            {
                return true;
            }
            return false;
        }
    }
}
