using MessageAppDemo2.Backend.Users.UserData;
using System;

namespace MessageAppDemo2.Backend.Login_SignUp.UserLoginClass
{
    public class BlockedPersonAuth : BaseAuth
    {
            
        public BlockedPersonAuth(BlockedPerson Instance) : base(Instance)
        {

        }
        public BlockedPersonAuth()
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
