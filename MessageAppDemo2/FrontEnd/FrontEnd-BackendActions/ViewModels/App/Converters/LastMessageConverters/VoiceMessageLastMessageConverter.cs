using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.ExtensionClasses;
using MessageAppDemo2.FrontEnd.Resources.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters.LastMessageConverters
{
    public class VoiceMessageLastMessageConverter : ILastMessageConverter
    {
        public LastMessage Convert(MessageBase Lastmessage)
        {
            if (Lastmessage is null)
            {
                return new LastMessage(IconResources.empty.ToBitmapImage(), "There is no message here!");
            }
            if (Lastmessage is not VoiceMessage)
            {
                throw new ArgumentException("Wrong Type");
            }
            else
            {
                return new LastMessage(IconResources.wave_sound.ToBitmapImage(), "Voice Message");
            }
        }
    }
}
