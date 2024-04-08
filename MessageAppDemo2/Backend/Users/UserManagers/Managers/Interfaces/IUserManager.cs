using MessageAppDemo2.Backend.SystemData.BasicCRUDSupport;
using MessageAppDemo2.Backend.Users.UserData;

namespace MessageAppDemo2.Backend.Users.UserManagers.Managers.Interfaces
{
    public interface IUserManager<Item, ID> : IBasicCrudSupport<Item, ID> where Item : User
    {
    }
}
