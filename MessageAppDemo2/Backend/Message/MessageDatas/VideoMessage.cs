using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.Users.UserData;

namespace MessageAppDemo.Backend.Message.MessageDatas
{
    public class VideoMessage : MessageBase, IHaveQuotedMessage, IHaveTextMessage
    {
        private MessageBase _QuotedMessage;
        private string _Text;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public VideoMessage()
        {
            _QuotedMessage = null;
            _Text = string.Empty;
        }
        public override object Clone()
        {
            VideoMessage ClonedInstance = this.MemberwiseClone() as VideoMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
