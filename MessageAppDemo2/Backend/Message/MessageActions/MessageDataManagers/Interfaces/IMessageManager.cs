using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo2.Backend.SystemData.BasicCRUDSupport;

namespace MessageAppDemo2.Backend.Message.MessageActions.MessageDataManagers.Interfaces
{
    public interface IMessageManager<Item, ID> : IBasicCrudSupport<Item, ID> where Item : MessageBase
    {
        ChatBase DependentChat { get; set; }
    }
}
