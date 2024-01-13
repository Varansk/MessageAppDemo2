using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.DataBase.Repositorys.Interfaces;
using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;

namespace MessageAppDemo.Backend.DataBase.Repositorys.RepositoryExtensions
{
    public static class MessageRepositoryExtensions
    {
        public static void SetDependentChat(this DatabaseRepository<MessageBase, int> repo, ChatBase Chat)
        {
            (repo.GeneralRepository as IChatSelector).SetDependentChat(Chat);
        }
    }
}
