using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.SystemData.BasicCRUDSupport;

namespace MessageAppDemo.Backend.Chatting.ChatActions.ChatManagers.Interfaces
{
    public interface IChatManager<Item, ID> : IBasicCrudSupport<Item, ID> where Item : ChatBase
    {
    }
}
