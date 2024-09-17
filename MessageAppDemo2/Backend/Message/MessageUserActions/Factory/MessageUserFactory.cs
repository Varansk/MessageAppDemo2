using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageRelatedActions;
using MessageAppDemo2.Backend.Message.MessageUserChatActions;
using MessageAppDemo2.Backend.SystemData.IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Message.MessageUserActions.Factory
{
    public class MessageUserFactory : FactoryBase<dynamic, MessageType>
    {
        protected override Dictionary<MessageType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                Dictionary<MessageType, Type> result = new Dictionary<MessageType, Type>()
                {
                    {MessageType.TextMessage,typeof(TextMessageUserActions) },
                    {MessageType.VoiceMessage,typeof(VoiceMessageUserActions)},
                    {MessageType.PictureMessage,typeof(PictureMessageUserActions)},
                    {MessageType.VideoMessage,typeof(VideoMessageUserActions)}
                };

                return result;
            }
        }
    }
}
