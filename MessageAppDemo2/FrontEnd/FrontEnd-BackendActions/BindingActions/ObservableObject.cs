using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions
{
    public class ObservableObject : IObservableObject
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public void OnPropertyChanged(PropertyChangedEventArgs Args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, Args);
            }
        }
    }
}
