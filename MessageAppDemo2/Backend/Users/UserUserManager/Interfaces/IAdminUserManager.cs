using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IAdminUserManager<AdminType> : IUserUserManager<Admin> where AdminType : IAdmin
    {
        bool BanUser(AdminType Banner, User Banned, BanInformation Information);
        bool UnBanUser(AdminType Banner, BlockedPerson Banned);
    }
}
