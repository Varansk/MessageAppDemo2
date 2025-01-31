using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RealTimeServicePool;
using MessageAppDemo2.Backend.DataBase.DatabaseObjectPools.RepositoryPools;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue;
using MessageAppDemo2.Backend.DataBase.RealTimeQueue.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.Message.MessageUserActions.Factory;
using MessageAppDemo2.FrontEnd.FrontEnd_BackendActions.ViewModels.App.HelperClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace MessageAppDemo2.Backend.Message.MessageUserActions
{
    public class MessageUserManager
    {
        public void SendMessage<messageType>(messageType Message, string ChannelID, string Route, string SenderGuid) where messageType : MessageBase
        {
            MessageUserFactory messagefac = new();

            dynamic messageuseract = messagefac.CreateInstance((MessageType)Message);

            messageuseract.GetType().GetMethod("SendMessage").Invoke(messageuseract, new object[] { Message, ChannelID, Route, SenderGuid });
        }
        public void RemoveMessage(MessageType messageType, string MessageID, string ChannelID, string Route)
        {
            MessageUserFactory messagefac = new();

            dynamic messageuseract = messagefac.CreateInstance(messageType);

            messageuseract.RemoveMessage(MessageID, ChannelID, Route);
        }
        public void EditMessage<messageType>(string MessageID, string ChannelID, string Route, messageType NewMessage, string SenderID) where messageType : MessageBase
        {
            MessageUserFactory messagefac = new();

            dynamic messageuseract = messagefac.CreateInstance((MessageType)NewMessage);

            messageuseract.EditMessage(MessageID, ChannelID, Route, NewMessage, SenderID);
        }


        public string[] StartConsumeMessages<T>(string ChannelID, string Route, Dictionary<string, List<ProcessedMessage<T>>> ReceivedMessagesLog) where T : MessageBase
        {
            RealTimeService<MessageBase> realTimeService = RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Get();



            ReceivedMessagesLog.Clear();

            ReceivedMessagesLog.Add(".Added", new List<ProcessedMessage<T>>());
            ReceivedMessagesLog.Add(".Removed", new List<ProcessedMessage<T>>());
            ReceivedMessagesLog.Add(".Edited", new List<ProcessedMessage<T>>());


            realTimeService.OnMessageReceived += (sender, e) =>
            {
                if (e.Message.MessageChannelName == ChannelID && e.Message.Message.ChatRoute == Route)
                {
                    switch (e.Message.MessageAction)
                    {
                        case MessageAction.Add:
                            ReceivedMessagesLog[".Added"].Add(e.Message as ProcessedMessage<T>);
                            break;
                        case MessageAction.Delete:
                            ReceivedMessagesLog[".Removed"].Add(e.Message as ProcessedMessage<T>);
                            break;
                        case MessageAction.Edit:
                            ReceivedMessagesLog[".Edited"].Add(e.Message as ProcessedMessage<T>);
                            break;
                        default:
                            throw new ArgumentException("Unknown Type");

                    }
                }
            };

            string[] Tags = new string[3];

            string tag1 = realTimeService.StartConsumeMessages(ChannelID, Route + ".Added");
            string tag2 = realTimeService.StartConsumeMessages(ChannelID, Route + ".Removed");
            string tag3 = realTimeService.StartConsumeMessages(ChannelID, Route + ".Edited");


            Tags[0] = tag1;
            Tags[1] = tag2;
            Tags[2] = tag3;



            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTimeService);

            return Tags;
        }
        public void StopConsumeMessages(string[] Tags)
        {
            RealTimeService<MessageBase> realTimeService = RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Get();

            for (int i = 0; i < Tags.Length; i++)
            {
                realTimeService.StopConsumeMessages(Tags[i]);
            }

            RealTimeMessageServicePool.GetRealTimeMessageServicePool("RTS").Return(realTimeService);
        }
        public List<MessageBase> GetLastxxMessage(int LastMessageCount, string ChannelID, string Route)
        {
            DatabaseRepository<MessageBase, int> databaseRepository = DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Get();

            var LastxxMessage = databaseRepository.GetWhere((I) => { return I.DependentChatGuid.ToString() == ChannelID && I.ChatRoute == Route; }).OrderBy((I) => I.MessageSentDate).TakeLast(LastMessageCount);

            DatabaseMessageRepositoryPools.GetDatabaseMessageRepositoryPool("DTBR").Return(databaseRepository);

            return LastxxMessage.ToList();
        }
    }
}
