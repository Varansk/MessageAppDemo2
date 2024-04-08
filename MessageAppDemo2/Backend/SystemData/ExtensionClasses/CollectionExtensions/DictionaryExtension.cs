using System;
using System.Collections.Generic;
using System.Windows.Shell;

namespace MessageAppDemo2.Backend.SystemData.ExtensionClasses.CollectionExtensions
{
    public static class DictionaryExtension
    {
        public static Dictionary<T, K> Clone<T, K>(this Dictionary<T, K> value) where T : notnull
        {
            throw new NotImplementedException();
        }
    }
}
