using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator
{
    public class FakeBusinessPersonCreator : FakeUserCreator.Interfaces.FakeUserCreator, IFaker<BusinessPerson>
    {
        public FakeBusinessPersonCreator() : base(new BusinessPerson(Guid.NewGuid()))
        {
        }
        public override BusinessPerson CreateFakeData()
        {
            _User = base.CreateFakeData();

            return _User as BusinessPerson;
        }
    }
}
