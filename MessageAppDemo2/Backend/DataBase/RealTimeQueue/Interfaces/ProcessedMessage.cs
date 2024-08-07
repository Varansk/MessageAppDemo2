using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces
{
    public record class ProcessedMessage<messageType> where messageType : class
    {
        public DateTime MessageSended { get; init; }
        public messageType Message { get; init; }
        public MessageType MessageType { get; init; }
        public string MessageChannelName { get; init; }
        public string MessageSenderID { get; init; }
        public string RoutingKey { get; init; }
        public string MessageID { get; init; }
        public MessageAction MessageAction { get; init; }

    }

    public enum MessageAction
    {
        Add, Delete, Edit
    }
}
