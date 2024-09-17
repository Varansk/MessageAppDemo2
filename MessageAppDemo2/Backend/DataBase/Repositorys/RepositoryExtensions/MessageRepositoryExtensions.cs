using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;
using System;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.RepositoryExtensions
{
    public static class MessageRepositoryExtensions
    {
        public static void SetDependentChat(this DatabaseRepository<MessageBase, int> repo, ChatBase Chat)
        {
            repo.SaveAllChanges();
            (repo.GeneralRepository as IChatSelector).SetDependentChat(Chat);
            repo.UpdateVirtualList();
        }
        public static void SetDependentChat(this DatabaseRepository<MessageBase, int> repo, Guid ChatID)
        {
            repo.SaveAllChanges();
            (repo.GeneralRepository as IChatSelector).SetDependentChat(ChatID);
            repo.UpdateVirtualList();
        }
        public static void SetRoute(this DatabaseRepository<MessageBase, int> repo, string Route)
        {
            repo.SaveAllChanges();
            (repo.GeneralRepository as IChatSelector).SetRoute(Route);
            repo.UpdateVirtualList();
        }
    }
}
