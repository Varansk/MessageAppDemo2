using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Users.UserData;

namespace MessageAppDemo.Backend.Chatting.ChatUserActions.Interfaces
{
    public class ChatUserManager
    {
        public void JoinChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, User User ) where ChatType : ChatBase
        {
            ChatUserManager.JoinChat(Chat, User);
        }
        public void LeaveChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, UserIDType ID) where ChatType : ChatBase
        {
            ChatUserManager.LeaveChat(Chat, ID);
        }
    }
}
