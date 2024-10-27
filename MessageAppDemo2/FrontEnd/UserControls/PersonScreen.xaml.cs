using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MessageAppDemo2.FrontEnd.UserControls
{
    /// <summary>
    /// PersonScreen.xaml etkileşim mantığı
    /// </summary>
    public partial class PersonScreen : UserControl
    {
        private PersonScreenMainViewModel _personScreenMainViewModel;

        public PersonScreen()
        {
            InitializeComponent();

            Application.Current.MainWindow.Height = 600;
            Application.Current.MainWindow.Width = 1000;

            _personScreenMainViewModel = new();
            this.DataContext = _personScreenMainViewModel;
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            _personScreenMainViewModel.DragDropCommand.Execute(e);
        }
    }
}
