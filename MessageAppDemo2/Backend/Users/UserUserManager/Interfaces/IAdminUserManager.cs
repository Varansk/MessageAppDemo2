using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IAdminUserManager : IUserUserManager<Admin>
    {
        void BanUser(Admin Banner, User Banned, BanInformation Information);
        void UnBanUser(Admin Banner, User Banned);
    }
}
