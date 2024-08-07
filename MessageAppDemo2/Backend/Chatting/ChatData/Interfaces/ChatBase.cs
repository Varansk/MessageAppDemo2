using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Chatting.ChatData.Interfaces
{

    public abstract class ChatBase : ICloneable
    {
        public Guid ChatID { get; init; }
        public List<MessageBase> Messages { get; set; }
        public List<User> ChatUsers { get; set; }
        public abstract BitmapImage ChatPicture { get; set; }
        public abstract string ChatName { get; set; }
        public string ChatDetails { get; set; }
        private ChatBase()
        {
            Messages = new List<MessageBase>();
            ChatUsers = new List<User>();
        }
        public ChatBase(Guid ChatID) : this()
        {
            this.ChatID = ChatID;
        }

        public abstract object Clone();

        public static explicit operator ChatType(ChatBase chat)
        {
            switch (chat)
            {
                case NormalChat:
                    return ChatType.NormalChat;
                case GroupChat:
                    return ChatType.GroupChat;
                default:
                    throw new ArgumentException("Type Not Found");
            }
        }

    }

    public enum ChatType
    {
        NormalChat, GroupChat
    }
}
