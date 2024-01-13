using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageAppDemo.Backend.PersonalData
{

    public class PersonalChatList : ICloneable
    {
        public List<ChatBase> ListOfChats { get; set; }

        public PersonalChatList()
        {
            ListOfChats = new List<ChatBase>();
        }

        public object Clone()
        {
            PersonalChatList ClonedInstance = this.MemberwiseClone() as PersonalChatList;
            
            return ClonedInstance;
        }
    }
}
