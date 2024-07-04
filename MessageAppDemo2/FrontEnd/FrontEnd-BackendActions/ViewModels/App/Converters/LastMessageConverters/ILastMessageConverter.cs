using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters.LastMessageConverters
{
    public interface ILastMessageConverter
    {
        LastMessage Convert(MessageBase Lastmessage);
    }

    public record struct LastMessage(BitmapImage? Logo, string Information)
    {
    }
}
