using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.Users.UserData;
using System;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.Chatting.ChatData.Interfaces
{

    public abstract class ChatBase : ICloneable
    {
        public Guid ChatID { get; init; }
        public List<MessageBase> Messages { get; set; }
        public List<User> ChatUsers { get; set; }
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

    }
}
