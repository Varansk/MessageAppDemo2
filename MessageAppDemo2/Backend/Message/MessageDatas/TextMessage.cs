using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.SystemData.UploadedFile;
using MessageAppDemo.Backend.Users.UserData;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.Message.MessageDatas
{
    public class TextMessage : MessageBase, IFileUploadableMessage<UploadedFile<object>>, IHaveQuotedMessage, IHaveTextMessage
    {
        private MessageBase _QuotedMessage;
        private string _Text;
        private List<UploadedFile<object>> _Files;

        public MessageBase QuotedMessage { get { return _QuotedMessage; } set { _QuotedMessage = value; } }
        public string Text { get { return _Text; } set { _Text = value; } }
        public List<UploadedFile<object>> Files { get { return _Files; } set { _Files = value; } }
        public TextMessage()
        {
            _QuotedMessage = null;
            _Text = string.Empty;
            _Files = new List<UploadedFile<object>>();
        }
        public override object Clone()
        {
            TextMessage ClonedInstance = this.MemberwiseClone() as TextMessage;
            ClonedInstance.MessageSender = MessageSender.Clone() as User;
            ClonedInstance.WhichChatMessageSent = WhichChatMessageSent.Clone() as ChatBase;

            return ClonedInstance;
        }
    }

}
