using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MessageAppDemo2.Backend.PersonalData
{

    public class PersonalChatList : ICloneable
    {
        public List<ChatBase> ListOfChats { get; set; }
        public List<ChatBase> BlockedByChats { get; set; }

        public PersonalChatList()
        {
            ListOfChats = new List<ChatBase>();
            BlockedByChats = new List<ChatBase>();
        }

        public object Clone()
        {
            PersonalChatList ClonedInstance = MemberwiseClone() as PersonalChatList;

            return ClonedInstance;
        }
    }
}
