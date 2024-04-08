using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces
{
    public interface IChatSelector
    {
        void SetDependentChat(ChatBase chat);
    }
}
