using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.Users.UserData;

namespace MessageAppDemo.Backend.Message.MessageDatas
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
            VoiceMessage ClonedInstance = this.MemberwiseClone() as VoiceMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
