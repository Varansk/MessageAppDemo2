using System.Collections.Generic;

namespace MessageAppDemo.Backend.SystemData.ExtensionClasses.CollectionExtensions
{
    public static class DictionaryExtension
    {
        public static Dictionary<T, K> Clone<T, K>(this Dictionary<T, K> value) where T : notnull
        {
            Dictionary<T, K> CopiedDictionary = new Dictionary<T, K>();

            foreach (var key in value)
            {
                CopiedDictionary.Add(DeepCloner.DeepCloner.DeepClone(key.Key), DeepCloner.DeepCloner.DeepClone(key.Value));
            }
            return CopiedDictionary;
        }
    }
}
