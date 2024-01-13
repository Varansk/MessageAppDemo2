using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator
{
    public class FakeBlockedPersonCreator : FakeUserCreator.Interfaces.FakeUserCreator, IFaker<BlockedPerson>
    {
        public FakeBlockedPersonCreator() : base(new BlockedPerson(Guid.NewGuid()))
        {
        }
        public override BlockedPerson CreateFakeData()
        {
            _User = base.CreateFakeData();

            return _User as BlockedPerson;
        }

    }
}
