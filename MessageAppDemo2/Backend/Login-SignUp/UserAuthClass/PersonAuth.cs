using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.Login_SignUp
{
    internal class PersonAuth : BaseAuth<Person>
    {
        public PersonAuth(Person Instance) : base(Instance)
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
