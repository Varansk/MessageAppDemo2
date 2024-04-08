using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IUserUserManager
    {
        void BlockUser(User Blocker, User Blocked);
        void UnBlockUser(User Blocker, User Blocked);
        void AddFriend(User User1, User User2);
        void RemoveFriend(User User1, User User2);
    }
}
