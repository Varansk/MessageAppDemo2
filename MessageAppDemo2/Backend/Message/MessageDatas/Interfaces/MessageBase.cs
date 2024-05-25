using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Message.MessageDatas.Interfaces
{
    public abstract class MessageBase : ICloneable
    {
        public int MessageID { get; init; }
        public DateTime MessageSentDate { get; set; }
        public User MessageSender { get; set; }
        public ChatBase WhichChatMessageSent { get; set; }
        public object RawMessage { get { return this; } }
        public bool IsEdited { get; set; }
        public MessageBase()
        {
            MessageID = -1;
            MessageSentDate = new DateTime();
            IsEdited = false;
        }

        public abstract object Clone();

    }
}
