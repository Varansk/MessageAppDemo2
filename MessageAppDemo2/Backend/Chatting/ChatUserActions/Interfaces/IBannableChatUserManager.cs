using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions.Interfaces
{
    public interface IBannableChatUserManager<UserIDType, ChatType> : IChatUserManager<UserIDType, ChatType> where ChatType : ChatBase
    {
        bool BanUserFromChat(ChatType Chat,User Banned );

        bool UnBanUserFromChat(ChatType Chat, User Banned);
    }
}
