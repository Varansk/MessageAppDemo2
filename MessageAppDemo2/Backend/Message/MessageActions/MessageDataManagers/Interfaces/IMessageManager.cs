using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.SystemData.BasicCRUDSupport;

namespace MessageAppDemo.Backend.Message.MessageActions.MessageDataManagers.Interfaces
{
    public interface IMessageManager<Item, ID> : IBasicCrudSupport<Item, ID> where Item : MessageBase
    {
        ChatBase DependentChat { get; set; }
    }
}
