using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.Converters.LastMessageConverters.Factory
{
    public class LastMessageConverterFactory : FactoryBase<ILastMessageConverter, MessageType>
    {
        protected override Dictionary<MessageType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                return new Dictionary<MessageType, Type>()
                {
                    {MessageType.TextMessage, typeof(TextMessageLastMessageConverter)   },
                    {MessageType.VoiceMessage, typeof(VoiceMessageLastMessageConverter) },
                    {MessageType.PictureMessage,typeof(PictureMessageLastMessageConverter) },
                    {MessageType.VideoMessage, typeof(VideoMessageLastMessageConverter) },
                };
            }
        }
    }
}
