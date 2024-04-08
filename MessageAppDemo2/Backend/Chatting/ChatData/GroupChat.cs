using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MessageAppDemo2.Backend.Chatting.ChatData
{

    public class GroupChat : ChatBase
    {
        public List<User> GroupAdminUsers { get; set; }
        public string ChatName { get; set; }
        public List<User> BlockedUsers { get; set; }
        public BitmapImage ChatPicture { get; set; }

        public GroupChat(Guid ChatID) : base(ChatID)
        {
            GroupAdminUsers = new List<User>(); 
            BlockedUsers = new List<User>();
        }
        public GroupChat() : this(Guid.NewGuid()) 
        {

        }

        public override object Clone()
        {
            GroupChat ClonedInstance = MemberwiseClone() as GroupChat;
            ClonedInstance.ChatPicture = ChatPicture.Clone() as BitmapImage;

            return ClonedInstance;
        }
    }
}
