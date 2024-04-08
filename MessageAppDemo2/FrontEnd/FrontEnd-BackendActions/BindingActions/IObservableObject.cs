using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.BindingActions
{
    public interface IObservableObject : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string PropertyName = null);
        void OnPropertyChanged(PropertyChangedEventArgs Args);
    }
}
