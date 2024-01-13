using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator
{
    public class FakePersonCreator : FakeUserCreator.Interfaces.FakeUserCreator, IFaker<Person>
    {
        public FakePersonCreator() : base(new Person(Guid.NewGuid()))
        {
        }
        public override Person CreateFakeData()
        {
            _User = base.CreateFakeData();

            return _User as Person;
        }
    }
}
