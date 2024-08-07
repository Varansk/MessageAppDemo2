﻿using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager.Interfaces
{
    public interface IHighLevelAdminUserManager<UserType> : IAdminUserManager<HighLevelAdmin>
    {
        bool BanAdmin(HighLevelAdmin User1, UserType User2, BanInformation BanInformation);
    }
}
