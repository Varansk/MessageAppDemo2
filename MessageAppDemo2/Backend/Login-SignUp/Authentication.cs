using MessageAppDemo.Backend.Users.UserData;

namespace MessageAppDemo.Backend.Login_SignUp
{
    public class Authentication
    {
        public bool Login<T>(BaseAuth<T> User) where T : User, new()
        {
            return User.Login();
        }
        public bool SignUp<T>(BaseAuth<T> User) where T : User, new()
        {
            return User.SignUp();
        }
    }
}
