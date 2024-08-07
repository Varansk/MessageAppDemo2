using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;   

namespace MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces
{
    public interface IMessageQueueService<MessageType> where MessageType : class
    {
        event EventHandler<MessageEventArgs<MessageType>> OnMessageReceived;
        IReadOnlyDictionary<string, IReadOnlyList<ProcessedMessage<MessageType>>> QueuesLog { get; }
        void CreateMessageChannel(string ChannelName);
        void SendMessage(string ChannelName, string RoutingKey, ProcessedMessage<MessageType> Message);
        string StartConsumeMessages(string ChannelName, string RoutingKey);
        void StopConsumeMessages(string ConsumerTag);
    }

    public class MessageEventArgs<messageType> : EventArgs where messageType : class
    {
        private readonly ProcessedMessage<messageType> _message;
        public ProcessedMessage<messageType> Message { get { return _message; } }
        public MessageEventArgs(ProcessedMessage<messageType> TheMessage)
        {
            this._message = TheMessage;
        }
    }
}
