using MessageAppDemo2.Backend.Login_SignUp.UserAuthClass.Interfaces;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.ValueChecksAndControls;

namespace MessageAppDemo2.Backend.Login_SignUp
{
    public class Authentication
    {
        public bool Login(User User)
        {
            User user = UserValueChecks.FindUser(User);
            
            if(user != null)
            {
                AuthFactory authFactory = new AuthFactory();

                BaseAuth baseAuth = authFactory.CreateInstanceWithParameter(user.UserType, user);

                return baseAuth.Login();
            }
            return false;
            
        }
        public bool SignUp(User User)
        {
            AuthFactory authFactory = new AuthFactory();

            BaseAuth baseAuth = authFactory.CreateInstanceWithParameter(User.UserType, User);

            return baseAuth.SignUp();
        }
    }
}
