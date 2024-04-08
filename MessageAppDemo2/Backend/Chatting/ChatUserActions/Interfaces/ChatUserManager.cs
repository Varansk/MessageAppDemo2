using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces
{
    public class ChatUserManager
    {
        public void JoinChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, User User) where ChatType : ChatBase
        {
            ChatUserManager.JoinChat(Chat, User);
        }
        public void LeaveChat<UserIDType, ChatType>(IChatUserManager<UserIDType, ChatType> ChatUserManager, ChatType Chat, UserIDType ID) where ChatType : ChatBase
        {
            ChatUserManager.LeaveChat(Chat, ID);
        }
        public bool BanUserFromChat<UserIDType, ChatType>(IBannableChatUserManager<UserIDType, ChatType> BannableChatUserManager, ChatType Chat, User Banned) where ChatType : ChatBase
        {
            return BannableChatUserManager.BanUserFromChat(Chat, Banned);
        }
        public bool UnBanUserFromChat<UserIDType, ChatType>(IBannableChatUserManager<UserIDType, ChatType> BannableChatUserManager, ChatType Chat, User Banned) where ChatType : ChatBase
        {
            return BannableChatUserManager.UnBanUserFromChat(Chat, Banned);
        }
    }
}
