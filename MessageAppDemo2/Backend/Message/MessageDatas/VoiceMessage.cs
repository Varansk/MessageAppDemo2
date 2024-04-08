using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Users.UserData;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class VoiceMessage : MessageBase, IHaveQuotedMessage
    {
        private MessageBase _QuotedMessage;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }

        public VoiceMessage()
        {
            _QuotedMessage = null;
        }
        public override object Clone()
        {
            VoiceMessage ClonedInstance = MemberwiseClone() as VoiceMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
