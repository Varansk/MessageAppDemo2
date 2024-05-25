using MessageAppDemo2.Backend.ReportSystem;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IUserUserManager<UserType> where UserType : User
    {
        bool BlockUser(UserType Blocker, User Blocked);
        bool UnBlockUser(UserType Blocker, User Blocked);
        bool AddFriend(UserType User1, User User2);
        bool RemoveFriend(UserType User1, User User2);
        bool Report(UserReport ReportDetails);
    }
}   
