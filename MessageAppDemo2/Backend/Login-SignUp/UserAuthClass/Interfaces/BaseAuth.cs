using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.ValueChecksAndControls;
using System;

namespace MessageAppDemo2.Backend.Login_SignUp
{
    public abstract class BaseAuth
    {
        public virtual bool Login()
        {
            return (Instance is not null) && (UserValueChecks.FindUser(Instance) is not null);
        }
        public virtual bool SignUp()
        {
            Func<User, bool> Func = UserValueChecks.CheckName;
            Func += UserValueChecks.CheckLastName;
            Func += UserValueChecks.CheckEmail;
            Func += UserValueChecks.CheckPassword;
            Func += UserValueChecks.CheckPhoneNumber;

            return UserValueChecks.CheckUser(Instance, Func) && !UserValueChecks.IsThisNumberExists(Instance);
        }
        public User Instance { get; set; }
        public BaseAuth(User User)
        {
            Instance = User;
        }
        public BaseAuth()
        {

        }
    }
}
