using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MessageAppDemo2.Backend.DataBase.RealTimeQueue
{
    public class RealTimeService<MessageType> where MessageType : class
    {
        private IMessageQueueService<MessageType> _messageService;

        public RealTimeService(IMessageQueueService<MessageType> RealTimeService)
        {
            this._messageService = RealTimeService;
        }

        public event EventHandler<MessageEventArgs<MessageType>> OnMessageReceived
        {
            add
            {
                _messageService.OnMessageReceived += value;
            }
            remove
            {
                _messageService.OnMessageReceived -= value;
            }
        }


        public IReadOnlyDictionary<string, IReadOnlyList<ProcessedMessage<MessageType>>> QueuesLog
        {
            get
            {
                return _messageService.QueuesLog;
            }
        }

        public void CreateMessageChannel(string ChannelName)
        {
            try
            {
                _messageService.CreateMessageChannel(ChannelName);
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectionError");
            }

        }

        public void SendMessage(string ChannelName, string RoutingKey, ProcessedMessage<MessageType> Message)
        {
            try
            {
                _messageService.SendMessage(ChannelName, RoutingKey, Message);
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectionError");
            }

        }

        public string StartConsumeMessages(string ChannelName, string RoutingKey)
        {
            try
            {
                return _messageService.StartConsumeMessages(ChannelName, RoutingKey);
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectionError");
                return null;
            }

        }

        public void StopConsumeMessages(string ConsumerTag)
        {
            try
            {
                _messageService.StopConsumeMessages(ConsumerTag);
            }
            catch (Exception)
            {
                MessageBox.Show("ConnectionError");
            }
        }
    }
}
