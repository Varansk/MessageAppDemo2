using MessageAppDemo2.FrontEnd.FrontendHelpers.GeneralHelpers.Interfaces;
using MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers.Interfaces;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo2.FrontEnd.FrontendHelpers.WindowHelpers
{
    public class WindowHelper : IHelper, ILoad
    {



        public WindowHelper()
        {            
        }
        public static void Load(Window Window)
        {
            Window.Show();      
        }

        public static void Load(Window Window, UserControl Content)
        {
            Window.Content = Content;
            Window.Show();
        }

        public static void Load(Window Window, Action<Window> OnLoadedActions)
        {
            OnLoadedActions.Invoke(Window);
            Window.Show();
        }

        public static void Load(Window Window, UserControl Content, Action<Window> OnLoadedActions)
        {
            Window.Content = Content;
            OnLoadedActions.Invoke(Window);
            Window.Show();
        }
    }
}
