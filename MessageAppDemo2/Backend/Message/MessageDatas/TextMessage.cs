using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.UploadedFile;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System.Collections.Generic;

namespace MessageAppDemo2.Backend.Message.MessageDatas
{
    public class TextMessage : MessageBase, IFileUploadableMessage<UploadedFile>, IHaveQuotedMessage, IHaveTextMessage
    {
        private MessageBase _QuotedMessage;
        private string _Text;
        private List<UploadedFile> _Files;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public List<UploadedFile> Files { get { return _Files; } set { _Files = value; } }
        public TextMessage()
        {
            _QuotedMessage = null;
            _Text = string.Empty;
            _Files = new List<UploadedFile>();
        }
        public override object Clone()
        {
            TextMessage ClonedInstance = MemberwiseClone() as TextMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }

}
