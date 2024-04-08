using MessageAppDemo2.Backend.Login_SignUp.UserLoginClass;
using MessageAppDemo2.Backend.SystemData.IFactory;
using MessageAppDemo2.Backend.Users.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageAppDemo2.Backend.Login_SignUp.UserAuthClass.Interfaces
{
    public class AuthFactory : FactoryBase<BaseAuth, UserType>
    {
        protected override Dictionary<UserType, Type> EnumTypeKeyValuePairs
        {
            get
            {
                Dictionary<UserType, Type> keyValuePairs = new Dictionary<UserType, Type>
                {
                    { UserType.Person, typeof(PersonAuth) },
                    { UserType.Admin, typeof(AdminAuth) },
                    { UserType.BlockedPerson, typeof(BlockedPersonAuth) },
                    { UserType.BusinessPerson,typeof(BusinessPersonAuth) },
                    { UserType.HighLevelAdmin, typeof(HighLevelAdminAuth) }
                };
                return keyValuePairs;
            }
        }
    }
}
