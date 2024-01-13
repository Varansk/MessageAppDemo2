using MessageAppDemo.Backend.Message.MessageDatas.Interfaces;
using MessageAppDemo.Backend.SystemData.FakeDataCreator;

namespace MessageAppDemo.Backend.Message.MessageDatas.FakeMessageDataCreator.Interfaces
{
    public class FakeBaseMessageCreator : IFaker<MessageBase>
    {
        protected MessageBase _Message;
        public FakeBaseMessageCreator(MessageBase Message)
        {
            _Message = Message;
        }
        public MessageBase CreateFakeData()
        {
            _Message.MessageSentDate = Faker.DateTimeFaker.DateTimeBetweenYears(_Message.MessageSender.FirstRegisteredDay.Year, 50);
            _Message.IsEdited = Faker.BooleanFaker.Boolean();
            return _Message;
        }
    }
}
