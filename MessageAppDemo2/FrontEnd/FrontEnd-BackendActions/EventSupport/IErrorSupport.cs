using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.EventSupport
{
    public interface IErrorSupport
    {
        public event EventHandler<ErrorEventArgs> OnError;
    }

    public class ErrorEventArgs : EventArgs
    {
        public readonly string ErrorMessage;
        public ErrorEventArgs(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
}
