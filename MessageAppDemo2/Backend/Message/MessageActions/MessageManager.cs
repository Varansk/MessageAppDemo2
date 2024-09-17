using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Message.MessageActions
{
    public class MessageManager
    {
        public Guid DependentGuid { get; set; }
        public string Route { get; set; }
        public MessageManager(Guid DependentChat, string Route)
        {
            this.DependentGuid = DependentChat;
            this.Route = Route;
        }
        public MessageManager()
        {

        }

        public void Add<Item, ID>(IMessageManager<Item, ID> Manager, Item Message) where Item : MessageBase
        {
            Manager.DependentGuid = DependentGuid;
            Manager.Route = Route;
            Manager.Add(Message);

        }
        public void Remove<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID) where Item : MessageBase
        {
            Manager.DependentGuid = DependentGuid;
            Manager.Route = Route;
            Manager.Remove(MessageID);
        }
        public void Update<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID, Action<Item> Changes) where Item : MessageBase
        {
            Manager.DependentGuid = DependentGuid;
            Manager.Route = Route;
            Manager.Update(MessageID, Changes);
        }
        public Item GetByID<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID) where Item : MessageBase
        {
            Manager.DependentGuid = DependentGuid;
            Manager.Route = Route;
            return Manager.GetByID(MessageID);
        }
    }
}
