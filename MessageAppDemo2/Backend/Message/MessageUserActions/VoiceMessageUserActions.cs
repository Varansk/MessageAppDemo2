using MessageAppDemo2.Backend.Chatting.ChatData;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RealTimeServicePool;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers;
using MessageAppDemo2.Backend.Message.MessageActions;
using MessageAppDemo2.Backend.Message.MessageChatActions.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using System.Diagnostics;

namespace MessageAppDemo2.Backend.Message.MessageRelatedActions
{
    public class VoiceMessageUserActions : IMessageUserActions<VoiceMessage>
    {
        public void EditMessage(string MessageID, string ChannelID, string Route, VoiceMessage NewMessage, string SenderID)
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
                MessageType = MessageType.VoiceMessage,
                MessageID = MessageID
            };

            realTime.CreateMessageChannel(ChannelID);
            realTime.SendMessage(ChannelID, Route, message);

            var messagerepo = DatabaseMessageRepositoryPools.GetDatabaseUserRepositoryPool("DTBR").Get();

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
                MessageAction = MessageAction.Delete,
                Message = new VoiceMessage() { ChatRoute = Route },
                MessageChannelName = ChannelID,
                RoutingKey = (Route + ".Removed"),
                MessageType = MessageType.VoiceMessage
            };

            realTime.CreateMessageChannel(ChannelID);
            realTime.SendMessage(ChannelID, Route, message);

            MessageManager messageManager = new(Guid.Parse(ChannelID), Route);
            messageManager.Remove(new VoiceMessageManager(), int.Parse(MessageID));

            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTime);
        }

        public void SendMessage(VoiceMessage Message, string ChannelID, string Route, string SenderGuid)
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
            realTime.SendMessage(ChannelID, Route, processedMessage);



            MessageManager messageManager = new MessageManager(Guid.Parse(ChannelID), Route);
            messageManager.Add(new VoiceMessageManager(), Message);


            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTime);
        }
    }
}
