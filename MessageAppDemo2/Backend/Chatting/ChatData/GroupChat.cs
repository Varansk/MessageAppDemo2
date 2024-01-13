using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace MessageAppDemo.Backend.Chatting.ChatData
{

    public class GroupChat : ChatBase
    {
        public List<User> GroupAdminUsers { get; set; }
        public string ChatName { get; set; }
        public BitmapImage ChatPicture { get; set; }

        public GroupChat(Guid ChatID) : base(ChatID)
        {

        }
        public GroupChat() : base(Guid.NewGuid())
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
