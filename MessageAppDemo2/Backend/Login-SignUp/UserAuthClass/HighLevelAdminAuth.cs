using MessageAppDemo2.Backend.Users.UserData;
using System;

namespace MessageAppDemo2.Backend.Login_SignUp.UserLoginClass
{
    public class HighLevelAdminAuth : BaseAuth
    {
        public HighLevelAdminAuth(HighLevelAdmin Instance) : base(Instance)
        {
        }
        public HighLevelAdminAuth()
        {

        }
        public override bool Login()
        {
            throw new NotImplementedException();
        }

        public override bool SignUp()
        {
            throw new NotImplementedException();
        }
    }
}
