using MessageAppDemo2.Backend.SystemData.ObjectPooler;
using MessageAppDemo2.Backend.Users.UserData;

namespace MessageAppDemo2.Backend.Login_SignUp
{
    public static class LoggedUserPool
    {
        private static IObjectPooler<User> _LoggedUser;

        public static void AddLoggedUser(User user)
        {
            ObjectPool<User> pool = new ObjectPool<User>(() => user);
        }
        public static User GetLoggedUser()
        {
            return _LoggedUser.Get();
        }
        public static void ReturnLoggedUser(User user)
        {
            _LoggedUser.Return(user);
        }

    }
}
