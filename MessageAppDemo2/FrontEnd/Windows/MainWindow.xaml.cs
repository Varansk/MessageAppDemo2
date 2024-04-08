using MessageAppDemo2.FrontEnd.UserControls;
using System.Windows;

namespace MessageAppDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new LoginView();
        }
    }
}
