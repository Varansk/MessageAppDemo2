using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.Login_SignUp.UserLoginClass
{
    internal class BusinessPersonAuth : BaseAuth<BusinessPerson>
    {
        public BusinessPersonAuth(BusinessPerson Instance) : base(Instance)
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
