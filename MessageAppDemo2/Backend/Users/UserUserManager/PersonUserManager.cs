using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserUserManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserUserManager
{
    public class PersonUserManager : IUserUserManager<Person>
    {
        public void AddFriend(Person User1, User User2)
        {
            throw new NotImplementedException();
        }

        public void BlockUser(Person Blocker, User Blocked)
        {
            throw new NotImplementedException();
        }

        public void RemoveFriend(Person User1, User User2)
        {
            throw new NotImplementedException();
        }

        public void Report(Person Reporter)
        {
            throw new NotImplementedException();
        }

        public void UnBlockUser(Person Blocker, User Blocked)
        {
            throw new NotImplementedException();
        }
    }
}
