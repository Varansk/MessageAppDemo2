using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.CodeDom;

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

        public static explicit operator MessageType(MessageBase message)
        {
            switch (message)
            {
                case TextMessage:
                    return MessageType.TextMessage;
                case VideoMessage:
                    return MessageType.VideoMessage;
                case VoiceMessage:
                    return MessageType.VoiceMessage;
                case PictureMessage:
                    return MessageType.PictureMessage;
                default:
                    throw new ArgumentException("Type Not Found");
            }
        }

    }

    public enum MessageType
    {
        TextMessage, VoiceMessage, VideoMessage, PictureMessage
    }
}
