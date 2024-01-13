using MessageAppDemo.Backend.Users.UserData;
using MessageAppDemo.Backend.Users.UserManagers.Managers.Interfaces;
using System;

namespace MessageAppDemo.Backend.Users.UserManagers
{
    public class UserManager
    {
        public void Add<Item, ID>(IUserManager<Item, ID> UserManager, Item User) where Item : User
        {
            UserManager.Add(User);
        }
        public void Remove<Item, ID>(IUserManager<Item, ID> UserManager, ID UserID) where Item : User
        {
            UserManager.Remove(UserID);
        }
        public void Update<Item, ID>(IUserManager<Item, ID> UserManager, ID UserID, Action<Item> Changes) where Item : User
        {
            UserManager.Update(UserID, Changes);
        }
        public Item GetByID<Item, ID>(IUserManager<Item, ID> UserManager, ID UserID) where Item : User
        {
            return UserManager.GetByID(UserID);
        }

    }
}
