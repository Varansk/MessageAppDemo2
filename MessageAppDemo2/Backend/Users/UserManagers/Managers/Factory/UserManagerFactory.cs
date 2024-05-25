using MessageAppDemo2.Backend.SystemData.IFactory;
using MessageAppDemo2.Backend.Users.UserData;
using MessageAppDemo2.Backend.Users.UserData.Interfaces;
using MessageAppDemo2.Backend.Users.UserManagers.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Users.UserManagers.Managers.Factory
{
    public class UserManagerFactory : FactoryBase<dynamic, UserType>
    {
        protected override Dictionary<UserType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                Dictionary<UserType, Type> keyValuePairs = new Dictionary<UserType, Type>()
                {
                    {UserType.Person,typeof(PersonManager) },
                    {UserType.BusinessPerson,typeof(BusinessPersonManager) },
                    {UserType.BlockedPerson,typeof(BlockedPersonManager) },
                    {UserType.Admin,typeof(AdminManager) },
                    {UserType.HighLevelAdmin,typeof(HighLevelAdminManager) }
                };

                return keyValuePairs;
            }
        }
    }
}
