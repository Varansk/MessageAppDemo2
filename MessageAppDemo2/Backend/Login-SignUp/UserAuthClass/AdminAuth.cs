using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.Login_SignUp.UserLoginClass
{
    internal class AdminAuth : BaseAuth<Admin>
    {

        public AdminAuth(Admin Instance) : base(Instance)
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
