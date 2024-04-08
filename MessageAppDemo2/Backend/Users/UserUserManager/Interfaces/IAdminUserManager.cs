using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IAdminUserManager : IUserUserManager
    {
        void BanUser(User Banner, User Banned, BanInformation Information);
        void UnBanUser(User Banner, User Banned);
    }
}
