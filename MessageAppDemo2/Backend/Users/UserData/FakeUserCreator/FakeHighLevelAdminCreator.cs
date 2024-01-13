using MessageAppDemo.Backend.SystemData.FakeDataCreator;
using System;

namespace MessageAppDemo.Backend.Users.UserData.FakeUserCreator
{
    public class FakeHighLevelAdminCreator : FakeUserCreator.Interfaces.FakeUserCreator, IFaker<HighLevelAdmin>
    {
        public FakeHighLevelAdminCreator() : base(new HighLevelAdmin(Guid.NewGuid()))
        {
        }
        public override HighLevelAdmin CreateFakeData()
        {
            _User = base.CreateFakeData();

            return _User as HighLevelAdmin;
        }
    }
}
