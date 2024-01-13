using MessageAppDemo.Backend.SystemData.ChangeController.Interfaces;
using MessageAppDemo.Backend.Users.UserData;
using System;

namespace MessageAppDemo.Backend.SystemData.ChangeController
{
    public class UserController : BaseController<User>
    {
        public override Func<User, User, bool> AddRemoveController
        {
            get
            {
                Func<User, User, bool> ControllerHandler = (User1, User2) =>
                {
                    return User1.UserGUİD == User2.UserGUİD;
                };

                return ControllerHandler;
            }
        }

        public override Func<User, User, bool> UpdateController
        {
            get
            {
                Func<User, User, bool> ControllerHandler = (User1, User2) =>
                {
                    bool A = User1.UserGUİD == User2.UserGUİD;
                    bool b = User1.Name == User2.Name;
                    bool c = User1.LastName == User2.LastName;
                    bool d = User1.PhoneNumber == User2.PhoneNumber;
                    bool e = User1.Email == User2.Email;
                    bool f = User1.Password == User2.Password;
                    bool g = User1.UserSignature == User2.UserSignature;
                    bool h = User1.ProfilePicture == User2.ProfilePicture;
                    bool i = User1.BirthDay == User2.BirthDay;
                    bool j = User1.FirstRegisteredDay == User2.FirstRegisteredDay;

                    return A && !(b && c && d && e && f && g && h && i && j);
                };

                return ControllerHandler;
            }
        }
    }
}
