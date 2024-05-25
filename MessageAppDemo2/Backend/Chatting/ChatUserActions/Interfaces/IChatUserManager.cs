using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces
{
    public interface IChatUserManager<UserIDType, ChatType> where ChatType : ChatBase
    {
        /// <summary>
        /// If the user is not in the chat, it adds them to the chat.
        /// </summary>
        bool JoinChat(ChatType Chat, User User);
        /// <summary>
        /// If the user is in the chat, it removes them from the chat.
        /// </summary>
        bool LeaveChat(ChatType Chat, UserIDType UserID);

        
    }
}
