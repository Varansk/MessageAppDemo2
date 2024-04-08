using System;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers.Interfaces
{
    public interface ILoad
    {
        static abstract void Load(Window Window);
        static abstract void Load(Window Window, UserControl Content);
        static abstract void Load(Window Window, Action<Window> OnLoadedActions);
        static abstract void Load(Window Window, UserControl Content, Action<Window> OnLoadedActions);
    }
}
