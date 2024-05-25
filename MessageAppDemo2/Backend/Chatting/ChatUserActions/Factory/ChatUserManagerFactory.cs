using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.SystemData.IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Chatting.ChatUserActions.Factory
{
    public class ChatUserManagerFactory : FactoryBase<dynamic, ChatType>
    {
        protected override Dictionary<ChatType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                return new Dictionary<ChatType, Type>()
                {
                    { ChatType.NormalChat, typeof(NormalChatUserManager) },
                    { ChatType.GroupChat, typeof(GroupChatUserManager) }
                };
            }
        }
    }
}