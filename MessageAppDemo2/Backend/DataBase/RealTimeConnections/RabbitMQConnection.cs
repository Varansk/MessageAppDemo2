using MessageAppDemo2.Backend.DataBase.RealTimeConneciton.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageAppDemo2.Backend.DataBase.RealTimeConnections
{
    public class RabbitMQConnection : IBasicAMQPService
    {
        private readonly string ConnectionString;

        public RabbitMQConnection(string Uri)
        {
            this.ConnectionString = Uri;
        }

        ~RabbitMQConnection()
        {
            CloseConnection();
        }

        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;


        public IConnection GetConnection
        {
            get { return connection; }
        }
        public IModel GetChannel
        {
            get { return channel; }
        }
        public EventingBasicConsumer GetEventingBasicConsumer
        {
            get { return consumer; }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                channel.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool OpenConnection()
        {
            try
            {
                ConnectionFactory connectionFactory = new ConnectionFactory();
                connectionFactory.Uri = new Uri(ConnectionString);

                connection = connectionFactory.CreateConnection();
                channel = connection.CreateModel();
                consumer = new EventingBasicConsumer(channel);
                return true;

            }
            catch (Exception)
            {
                CloseConnection();
                return false;
            }

        }
    }
}
