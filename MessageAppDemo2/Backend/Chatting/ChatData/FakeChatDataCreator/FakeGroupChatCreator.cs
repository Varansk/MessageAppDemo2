using MessageAppDemo.Backend.Chatting.ChatData.FakeChatDataCreator.Interfaces;
using MessageAppDemo.Backend.SystemData.ExtensionClasses;
using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Chatting.ChatData.FakeChatDataCreator
{
    public class FakeGroupChatCreator : FakeChatBaseCreator, IFaker<GroupChat>
    {
        public FakeGroupChatCreator() : base(new GroupChat(Guid.NewGuid()))
        {
        }

        public override GroupChat CreateFakeData()
        {
            _Chat = base.CreateFakeData();

            GroupChat _ChatG = _Chat as GroupChat;

            _ChatG.ChatName = Faker.TextFaker.Sentence();
            _ChatG.ChatPicture = MessageAppDemo.FrontEnd.Resources.Icons.IconResources.NoImageIcon.ToImage();

              
            return _ChatG;
           
        }

    }
}
