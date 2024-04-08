using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.SystemData.BasicCRUDSupport;

namespace MessageAppDemo2.Backend.Chatting.ChatActions.ChatManagers.Interfaces
{
    public interface IChatManager<Item, ID> : IBasicCrudSupport<Item, ID> where Item : ChatBase
    {
    }
}
