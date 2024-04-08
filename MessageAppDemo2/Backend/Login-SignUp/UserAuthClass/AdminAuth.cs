using MessageAppDemo2.Backend.Users.UserData;
using System;

namespace MessageAppDemo2.Backend.Login_SignUp.UserLoginClass
{
    public class AdminAuth : BaseAuth
    {

        public AdminAuth(Admin Instance) : base(Instance)
        {
            
        }
        public AdminAuth()
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
