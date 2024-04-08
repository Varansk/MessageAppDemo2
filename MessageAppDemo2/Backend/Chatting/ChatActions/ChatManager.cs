using MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers.Interfaces;
using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.Chatting.ChatActions
{
    public class ChatManager
    {
        public void Add<Item, ID>(IChatManager<Item, ID> ChatManager, Item Chat) where Item : ChatBase
        {
            ChatManager.Add(Chat);
        }
        public void Remove<Item, ID>(IChatManager<Item, ID> ChatManager, ID ChatID) where Item : ChatBase
        {
            ChatManager.Remove(ChatID);
        }
        public void Update<Item, ID>(IChatManager<Item, ID> ChatManager, ID ChatID, Action<Item> Changes) where Item : ChatBase
        {
            ChatManager.Update(ChatID, Changes);
        }
        public Item GetByID<Item, ID>(IChatManager<Item, ID> ChatManager, ID ChatID) where Item : ChatBase
        {
            return ChatManager.GetByID(ChatID);
        }

    }
}
