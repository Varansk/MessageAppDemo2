using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class PictureMessage : MessageBase, IHaveQuotedMessage, IHaveTextMessage, IFileUploadableMessage<PictureMessage>
    {
        private MessageBase _QuotedMessage;
        private string _Text;
        private List<PictureMessage> _Files;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public List<PictureMessage> Files { get { return _Files; } set { _Files = value; } }

        public PictureMessage()
        {
            _QuotedMessage = null;
            _Text = string.Empty;
            _Files = new List<PictureMessage>();
        }
        public override object Clone()
        {
            PictureMessage ClonedInstance = MemberwiseClone() as PictureMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }
}
