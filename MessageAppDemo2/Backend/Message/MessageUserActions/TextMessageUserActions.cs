using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RealTimeServicePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.RepositoryExtensions;
using MessageAppDemo2.Backend.Message.MessageActions;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers;
using MessageAppDemo2.Backend.Message.MessageChatActions.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageAppDemo2.Backend.Message.MessageUserChatActions
{
    public class TextMessageUserActions : IMessageUserActions<TextMessage>
    {
        public void EditMessage(string MessageID, string ChannelID, string Route, TextMessage NewMessage, string SenderID)
        {
            RealTimeService<MessageBase> realTime = RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Get();

            NewMessage.IsEdited = true;
            ProcessedMessage<MessageBase> message = new()
            {
                Message = NewMessage,
                MessageSended = DateTime.Now,
                MessageSenderID = NewMessage.MessageSenderID.ToString(),
                MessageAction = MessageAction.Edit,
                MessageChannelName = ChannelID,
                RoutingKey = (Route + ".Edited"),
                MessageType = MessageType.TextMessage,
                MessageID = MessageID
            };


            realTime.CreateMessageChannel(ChannelID);
            realTime.SendMessage(ChannelID, Route + ".Edited", message);

            var messagerepo = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();
            messagerepo.SetRoute(NewMessage.ChatRoute);
            messagerepo.SetDependentChat(Guid.Parse(ChannelID));

            messagerepo.UpdateWithPut(int.Parse(MessageID), NewMessage);

            DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Return(messagerepo);
            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTime);
        }



        public void RemoveMessage(string MessageID, string ChannelID, string Route)
        {
            RealTimeService<MessageBase> realTime = RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Get();

            ProcessedMessage<MessageBase> message = new()
            {
                MessageID = MessageID,
                Message = new TextMessage() { ChatRoute = Route },
                MessageAction = MessageAction.Delete,
                MessageChannelName = ChannelID,
                RoutingKey = (Route + ".Removed"),
                MessageType = MessageType.TextMessage
            };

            realTime.CreateMessageChannel(ChannelID);
            realTime.SendMessage(ChannelID, Route + ".Removed", message);

            MessageManager messageManager = new(Guid.Parse(ChannelID),Route);
            messageManager.Remove(new TextMessageManager(), int.Parse(MessageID));

            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTime);
        }

        public void SendMessage(TextMessage Message, string ChannelID, string Route, string SenderGuid)
        {
            RealTimeService<MessageBase> realTime = RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Get();
            ProcessedMessage<MessageBase> processedMessage = new()
            {
                Message = Message,
                MessageAction = MessageAction.Add,
                MessageChannelName = ChannelID,
                MessageID = Message.MessageID.ToString(),
                MessageSended = DateTime.Now,
                MessageSenderID = SenderGuid,
                MessageType = (MessageType)Message,
                RoutingKey = (Route + ".Added")
            };

            realTime.CreateMessageChannel(ChannelID);
            realTime.SendMessage(ChannelID, Route + ".Added", processedMessage);



            MessageManager messageManager = new MessageManager(Guid.Parse(ChannelID),Route);
            messageManager.Add(new TextMessageManager(), Message);


            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTime);
        }


    }
}

