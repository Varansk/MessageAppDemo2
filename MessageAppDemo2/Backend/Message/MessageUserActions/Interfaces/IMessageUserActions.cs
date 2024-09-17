using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Message.MessageChatActions.Interfaces
{
    public interface IMessageUserActions<messageType> where messageType : MessageBase
    {
        void SendMessage(messageType Message, string ChannelID, string Route, string SenderGuid);
        void RemoveMessage(string MessageID, string ChannelID, string Route);
        void EditMessage(string MessageID, string ChannelID, string Route, messageType NewMessage, string SenderID);
    }
}
