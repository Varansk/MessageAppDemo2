using MessageAppDemo.FrontEnd.FrontendHelpers.GeneralHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MessageAppDemo.FrontEnd.FrontendHelpers.WindowHelpers
{
    public class WindowHelper : IHelper, ILoad<Window>
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
