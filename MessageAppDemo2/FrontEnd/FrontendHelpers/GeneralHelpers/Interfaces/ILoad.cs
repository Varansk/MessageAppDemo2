using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo.FrontEnd.FrontendHelpers.GeneralHelpers.Interfaces
{
    public interface ILoad<ItemType> where ItemType : class
    {
        static abstract void Load(Window Window);
        static abstract void Load(Window Window, UserControl Content);
        static abstract void Load(Window Window, Action<ItemType> OnLoadedActions);
        static abstract void Load(Window Window, UserControl Content, Action<ItemType> OnLoadedActions);
    }
}
