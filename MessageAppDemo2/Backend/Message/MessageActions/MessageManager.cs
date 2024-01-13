using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Message.MessageActions.MessageDataManagers.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using System;

namespace MessageAppDemo.Backend.Message.MessageActions
{
    public class MessageManager
    {
        public ChatBase DependentChat { get; set; }
        public MessageManager(ChatBase DependentChat)
        {
            this.DependentChat = DependentChat;
        }
        public MessageManager()
        {

        }

        public void Add<Item, ID>(IMessageManager<Item, ID> Manager, Item Message) where Item : MessageBase
        {
            Manager.DependentChat = this.DependentChat;
            Manager.Add(Message);

        }
        public void Remove<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID) where Item : MessageBase
        {
            Manager.DependentChat = this.DependentChat;
            Manager.Remove(MessageID);
        }
        public void Update<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID, Action<Item> Changes) where Item : MessageBase
        {
            Manager.DependentChat = this.DependentChat;
            Manager.Update(MessageID, Changes);
        }
        public Item GetByID<Item, ID>(IMessageManager<Item, ID> Manager, ID MessageID) where Item : MessageBase
        {
            Manager.DependentChat = DependentChat;
            return Manager.GetByID(MessageID);
        }
    }
}
