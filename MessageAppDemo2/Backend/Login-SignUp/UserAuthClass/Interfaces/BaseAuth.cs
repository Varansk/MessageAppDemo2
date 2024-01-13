using MessageAppDemo.Backend.Users.UserData;
using MessageAppDemo.Backend.ValueChecksAndControls;
using System;

namespace MessageAppDemo.Backend.Login_SignUp
{
    public abstract class BaseAuth<T> where T : User
    {
        public virtual bool Login()
        {
            return true;
        }
        public virtual bool SignUp()
        {
            Func<User, bool> Func = UserValueChecks.CheckName;
            Func += UserValueChecks.CheckLastName;
            Func += UserValueChecks.CheckEmail;
            Func += UserValueChecks.CheckPassword;
            Func += UserValueChecks.CheckPhoneNumber;

            if (UserValueChecks.CheckUser(Instance, Func))
            {
                return true;
            }
            return false;
        }
        protected T Instance { get; set; }
        public BaseAuth(T User)
        {
            Instance = User;
        }
    }
}
