using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using System;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces
{
    public interface IChatSelector
    {
        void SetDependentChat(ChatBase chat);
        void SetDependentChat(Guid ChatID);
        void SetRoute(string Route);
    }
}
