using MessageAppDemo.Backend.SystemData.BasicCRUDSupport;
using MessageAppDemo.Backend.Users.UserData;

namespace MessageAppDemo.Backend.Users.UserManagers.Managers.Interfaces
{
    public interface IUserManager<Item, ID> : IBasicCrudSupport<Item,ID> where Item : User 
    {
    }
}
