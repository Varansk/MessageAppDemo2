using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator
{
    public class FakeAdminCreator : FakeUserCreator.Interfaces.FakeUserCreator, IFaker<Admin>
    {

        public FakeAdminCreator() : base(new Admin(Guid.NewGuid()))
        {
        }
        public override Admin CreateFakeData()
        {
            _User = base.CreateFakeData();

            return _User as Admin;
        }
    }
}
