using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IUserUserManager<UserType> where UserType : User
    {
        void BlockUser(UserType Blocker, User Blocked);
        void UnBlockUser(UserType Blocker, User Blocked);
        void AddFriend(UserType User1, User User2);
        void RemoveFriend(UserType User1, User User2);
        void Report(UserType Reporter);
    }
}   
