using MessageAppDemo2.Backend.Login_SignUp;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using System;
using System.Windows.Media.Imaging;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;

namespace MessageAppDemo2.Backend.Chatting.ChatData
{

    public class NormalChat : ChatBase
    {
        public string ChatName
        {
            get
            {
                User user = LoggedUserPool.GetLoggedUser();
                foreach (User item in ChatUsers)
                {
                    if (item.UserGUİD != user.UserGUİD)
                    {
                        if (user.PersonalUserLists.SavedUserNames.ContainsKey(item.UserGUİD))
                        {
                            return user.PersonalUserLists.SavedUserNames[item.UserGUİD];
                        }
                        else
                        {
                            return item.PhoneNumber;
                        }
                    }
                }
                return null;
            }
        }
        public BitmapImage ChatPicture
        {
            get
            {
                User user = LoggedUserPool.GetLoggedUser();
                foreach (User item in ChatUsers)
                {
                    if (item.UserGUİD != user.UserGUİD)
                    {
                        return item.ProfilePicture;
                    }
                }
                return null;
            }
        }
        public NormalChat(Guid ChatID) : base(ChatID)
        {

        }
        public NormalChat() : base(Guid.NewGuid())
        {

        }

        public override object Clone()
        {
            NormalChat ClonedInstance = MemberwiseClone() as NormalChat;

            return ClonedInstance;
        }
    }
}
