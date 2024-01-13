using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.Login_SignUp.UserLoginClass
{
    public class BlockedPersonAuth : BaseAuth<BlockedPerson>
    {
            
        public BlockedPersonAuth(BlockedPerson Instance) : base(Instance)
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
