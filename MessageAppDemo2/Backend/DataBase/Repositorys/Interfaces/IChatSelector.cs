using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;

namespace MessageAppDemo.Backend.DataBase.Repositorys.Interfaces
{
    public interface IChatSelector
    {
        void SetDependentChat(ChatBase chat);
    }
}
