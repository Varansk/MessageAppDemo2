using MessageAppDemo2.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo2.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo2.Backend.Message.MessageDatas.Interfaces;

namespace MessageAppDemo2.Backend.DataBase.Repositorys.RepositoryExtensions
{
    public static class MessageRepositoryExtensions
    {
        public static void SetDependentChat(this DatabaseRepository<MessageBase, int> repo, ChatBase Chat)
        {
            (repo.GeneralRepository as IChatSelector).SetDependentChat(Chat);
        }
    }
}
