using MessageAppDemo2.Backend.DataBase.RealTimeConnections;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.DataBase.RealTimeQueue
{
    public class RabbitMQMessageQueueService<MessageType> : IMessageQueueService<MessageType> where MessageType : class
    {
        protected RabbitMQConnection RabbitMQ;


        public RabbitMQMessageQueueService(RabbitMQConnection RabbitMQ)
        {
            this.RabbitMQ = RabbitMQ;
            RabbitMQ.OpenConnection();

            _messageQueues = new();
            _routesConsuming = new();
        }




        private readonly Dictionary<string, List<ProcessedMessage<MessageType>>> _messageQueues;
        private readonly List<string> _routesConsuming;


        public event EventHandler<MessageEventArgs<MessageType>> OnMessageReceived;

        public IReadOnlyList<string> RoutesConsuming
        {
            get
            {
                return _routesConsuming;
            }
        }
        public IReadOnlyDictionary<string, IReadOnlyList<ProcessedMessage<MessageType>>> QueuesLog
        {
            get
            {
                Dictionary<string, IReadOnlyList<ProcessedMessage<MessageType>>> readonlymessages = new();

                foreach (var item in _messageQueues)
                {
                    IReadOnlyList<ProcessedMessage<MessageType>> processedMessages = item.Value;
                    readonlymessages.Add(item.Key, processedMessages);
                }

                return readonlymessages;
            }
        }

        public void CreateMessageChannel(string ChannelName)
        {
            if (string.IsNullOrWhiteSpace(ChannelName))
            {
                throw new ArgumentException("InvalidName");
            }
            RabbitMQ.GetChannel.ExchangeDeclare(ChannelName, ExchangeType.Topic, false, false);
        }

        public void SendMessage(string ChannelName, string RoutingKey, ProcessedMessage<MessageType> Message)
        {

            // string serialized = System.Text.Json.JsonSerializer.Serialize(Message);

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
            settings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());
            settings.Converters.Add(new BitmapImageJsonConverter());

            string serialized = JsonConvert.SerializeObject(Message, typeof(ProcessedMessage<MessageType>), settings);
            byte[] byteMessage = Encoding.UTF8.GetBytes(serialized);

            RabbitMQ.GetChannel.BasicPublish(ChannelName, RoutingKey, null, byteMessage);

            /* byte[] messagebyte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Message,
                 new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                 }));

             RabbitMQ.GetChannel.BasicPublish(ChannelName, RoutingKey, null, messagebyte);*/
        }

        public string StartConsumeMessages(string ChannelName, string RoutingKey)
        {
            string QueueKey = ChannelName + RoutingKey;

            RabbitMQ.GetChannel.ExchangeDeclare(ChannelName, ExchangeType.Topic, false, false);

            string QueueName = RabbitMQ.GetChannel.QueueDeclare().QueueName;
            RabbitMQ.GetChannel.QueueBind(QueueName, ChannelName, RoutingKey);


            RabbitMQ.GetEventingBasicConsumer.Received += (sender, e) =>
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented
                };
                settings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());
                settings.Converters.Add(new BitmapImageJsonConverter());


                byte[] b = e.Body.ToArray();

                string s = Encoding.UTF8.GetString(b);

                ProcessedMessage<MessageType>? messageNormal = JsonConvert.DeserializeObject<ProcessedMessage<MessageType>>(s, settings);

                if (OnMessageReceived is not null)
                {
                    OnMessageReceived.Invoke(this, new MessageEventArgs<MessageType>(messageNormal));
                }                

                if (_messageQueues.ContainsKey(QueueKey))
                {
                    _messageQueues[QueueKey].Add(messageNormal);
                }
                else
                {
                    _messageQueues.Add(QueueKey, new List<ProcessedMessage<MessageType>>() { messageNormal });
                    _routesConsuming.Add(QueueKey);
                }

            };

            string tag = RabbitMQ.GetChannel.BasicConsume(QueueName, true, RabbitMQ.GetEventingBasicConsumer);


            return tag;
        }

        public void StopConsumeMessages(string ConsumerTag)
        {
            RabbitMQ.GetChannel.BasicCancel(ConsumerTag);
        }
    }
}
