using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters.LastMessageConverters;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters.LastMessageConverters.Factory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters
{
    public class ChatLastMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LastMessageConverterFactory factory = new LastMessageConverterFactory();
            ILastMessageConverter lastMessageConverter = factory.CreateInstance((MessageType)((value as ChatBase).Messages.Last()));

            return lastMessageConverter.Convert((value as ChatBase).Messages.Last());

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
