using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Chatting.ChatData.FakeChatDataCreator
{
    public class FakeNormalChatCreator : FakeChatDataCreator.Interfaces.FakeChatBaseCreator, IFaker<NormalChat>
    {
        public FakeNormalChatCreator() : base(new NormalChat(Guid.NewGuid()))
        {
        }
        public override NormalChat CreateFakeData()
        {
            _Chat = base.CreateFakeData();
            return _Chat as NormalChat;
        }
    }
}
