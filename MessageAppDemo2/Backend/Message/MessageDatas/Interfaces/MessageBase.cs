using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using Newtonsoft.Json;
using System;
using System.CodeDom;


namespace MessageAppDemo2.Backend.Message.MessageDatas.Interfaces
{
    public abstract class MessageBase : ICloneable
    {
        public int MessageID { get; init; }
        public DateTime MessageSentDate { get; set; }

        [JsonIgnore]
        public User MessageSender { get; set; }
        [JsonIgnore]
        public ChatBase WhichChatMessageSent { get; set; }
        [JsonIgnore]
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
