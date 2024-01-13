using MessageAppDemo.Backend.Chatting.ChatData.Interfaces;
using MessageAppDemo.Backend.SystemData.FakeDataCreator;

namespace MessageAppDemo.Backend.Chatting.ChatData.FakeChatDataCreator.Interfaces
{
    public abstract class FakeChatBaseCreator : IFaker<ChatBase>
    {
        protected ChatBase _Chat;
        public FakeChatBaseCreator(ChatBase Chat)
        {
            _Chat = Chat;
        }
        public virtual ChatBase CreateFakeData()
        {
            _Chat.ChatDetails = Faker.TextFaker.Sentences(2);

            return _Chat;
        }
    }
}
